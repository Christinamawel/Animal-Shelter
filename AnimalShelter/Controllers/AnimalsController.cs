using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index(int sortType)
    {
      List<Animal> model = new List<Animal> {};
      if (sortType == 0)
      {
      model = _db.Animals.ToList();
      }
      else if (sortType == 1)
      {
      model = (from animal in _db.Animals orderby animal.Name select animal).ToList();
      }
      else if (sortType == 2)
      {
      model = (from animal in _db.Animals orderby animal.Type, animal.Name select animal).ToList();
      }
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }
  }
}