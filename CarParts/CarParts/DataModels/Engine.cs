using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Engine
    {
        public ObjectId _id;
        string name;
        string model;
        string purpose;
        string vin;
        int price;
    }
}
