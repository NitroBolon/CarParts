using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Wheel
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public int diameter { get; set; }
        public string vin { get; set; }
        public int price { get; set; }
    }
}
