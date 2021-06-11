using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Wheel
    {
        public ObjectId _id;
        string name;
        string model;
        int diameter;
        string vin;
        int price;
    }
}
