using System;
using api_mongodb.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace api_mongodb.Data
{
  public class MongoDb
  {
    public IMongoDatabase DB { get; }
    public MongoDb(IConfiguration config)
    {
      try
      {
        var client = new MongoClient(new MongoUrl(config["ConnectionStrings"]));
        // var client = new MongoClient(settings);
        DB = client.GetDatabase(config["databaseName"]);
        MapClasses();
      }
      catch (Exception ex)
      {
        throw new MongoException("Could not connect to Mongo", ex);
      }
    }
    private void MapClasses()
    {
      var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
      ConventionRegistry.Register("camelCase", conventionPack, t => true);
      if (!BsonClassMap.IsClassMapRegistered(typeof(Infected)))
      {
        BsonClassMap.RegisterClassMap<Infected>(i =>
        {
          i.AutoMap();
          i.SetIgnoreExtraElements(true);
        });
      }
    }
  }
}