using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Suspension
    {
        public ObjectId _id;
        string name;
        string model;
        string purpose;
        string vin;
        int price;
    }
}
