using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Car
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string carId { get; set; }
        public string vin { get; set; }
        public int year { get; set; }
    }
}
