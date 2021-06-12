using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Suspension
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string purpose { get; set; }
        public string vin { get; set; }
        public int price { get; set; }
    }
}
