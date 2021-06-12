using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Client
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string car { get; set; }
        public string phone { get; set; }
    }
}
