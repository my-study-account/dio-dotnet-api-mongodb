using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace api_mongodb.Data.Collections
{
  public class Infected
  {
    public Infected(DateTime birthDate, string gender, double longitude, double latitude)
    {
      this.BirthDate = birthDate;
      this.Gender = gender;
      this.Localization = new GeoJson2DGeographicCoordinates(longitude, latitude);
    }

    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public GeoJson2DGeographicCoordinates Localization { get; set; }
  }
}