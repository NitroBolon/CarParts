using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Car
    {
        public ObjectId _id;
        string name;
        string model;
        string id;
        string vin;
        int year;
    }
}
