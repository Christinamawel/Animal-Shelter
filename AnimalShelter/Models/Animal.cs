using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Breed { get; set; }
    public bool Gender { get; set; }
    // true = female & false = male
    public DateTime DateOfAdmittance { get; set; }
  }
}