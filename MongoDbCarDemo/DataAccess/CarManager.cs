using DataAccess.Models;
using MongoDB.Driver;
using System;
using System.Drawing;

namespace DataAccess;

public class CarManager : IRepository<Car>
{
    private readonly IMongoCollection<Car> _collection;

    public CarManager()
    {
        var hostname = "localhost";
        var databaseName = "carDemo";
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Car>("cars", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }
    public void Add(Car item)
    {
        _collection.InsertOne(item);
    }

    public IEnumerable<Car> GetAll()
    {
        return _collection.Find(_ => true).ToEnumerable();
    }

    public IEnumerable<Car> GetByMake(string make)
    {
        return _collection
            .Find(p =>
                (!string.IsNullOrEmpty(make) && p.Make == make))
            .ToEnumerable();
    }

    public IEnumerable<Car> GetByModel(string model)
    {
        return _collection
            .Find(p =>
                (!string.IsNullOrEmpty(model) && p.Model == model))
            .ToEnumerable();
    }

    public IEnumerable<Car> GetByColor(string color)
    {
        return _collection
            .Find(p =>
                (!string.IsNullOrEmpty(color) && p.Color == color))
            .ToEnumerable();
    }

    public void UpdateMake(object id, string make)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Make", make);

        _collection
            .FindOneAndUpdate(
                filter,
        update,
        new FindOneAndUpdateOptions<Car, Car>
        {
                    IsUpsert = true
                }
            );
    }

    public void UpdateModel(object id, string model)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Make", model);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void UpdateColor(object id, string color)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Color", color);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void UpdateHorsePower(object id, int horsePower)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
        .Update
            .Set("HorsePower", horsePower);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void Replace(object id, Car item)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Make", item.Make)
            .Set("Model", item.Model)
            .Set("Color ", item.Color)
            .Set("HorsePower", item.HorsePower);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void Delete(object id)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        _collection.FindOneAndDelete(filter);
    }
}