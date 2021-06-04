using System;

namespace api_mongodb.Models
{
  public class InfectedDTO
  {
    public DateTime BirthDate { get; set; }
    public string Genders { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
  }
}