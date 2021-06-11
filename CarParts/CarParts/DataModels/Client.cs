using MongoDB.Bson;

namespace CarParts.DataModels
{
    public class Client
    {
        public ObjectId _id;
        string name;
        string address;
        string car;
        string phone;
    }
}
