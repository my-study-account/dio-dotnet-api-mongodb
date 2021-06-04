using api_mongodb.Data.Collections;
using api_mongodb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api_mongodb.Controllers
{
  [ApiController]
  [Route("[Controller]")]
  public class InfectedController : ControllerBase
  {
    Data.MongoDb _mongoDB;
    IMongoCollection<Infected> _infectedCollection;

    public InfectedController(Data.MongoDb mongoDB)
    {
      this._mongoDB = mongoDB;
      this._infectedCollection = this._mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
    }

    [HttpPost]
    public ActionResult SaveInfected([FromBody] InfectedDTO dto)
    {
      var infected = new Infected(dto.BirthDate, dto.Genders, dto.Latitude, dto.Longitude);
      _infectedCollection.InsertOne(infected);
      return StatusCode(201, "Infected successfully added!!!");
    }

    [HttpGet]
    public ActionResult GetInfected()
    {
      var infected = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();
      return Ok(infected);
    }
  }
}