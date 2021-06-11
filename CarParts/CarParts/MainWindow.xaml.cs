using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using CarParts.DataModels;

namespace CarParts
{
    public partial class MainWindow : Window
    {
        public MongoClient dbClient;
        public IMongoDatabase dbContext;
        public IMongoCollection<Car> Cars;
        public IMongoCollection<Engine> EngineParts;
        public IMongoCollection<Suspension> SuspensionParts;
        public IMongoCollection<Wheel> Wheels;
        public IMongoCollection<Client> Clients;

        public MainWindow()
        {
            InitializeComponent();

            dbClient = new MongoClient("mongodb://localhost:27017");
            dbContext = dbClient.GetDatabase("CarParts");

            if (dbContext == null || dbClient == null)
            {
                MessageBox.Show("Database connection not estabilished", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GetCollections();
        }

        private void GetCollections()
        {
            Cars = dbContext.GetCollection<Car>("Cars");
            Wheels = dbContext.GetCollection<Wheel>("Wheels");
            SuspensionParts = dbContext.GetCollection<Suspension>("Suspension");
            Clients = dbContext.GetCollection<Client>("Clients");
            EngineParts = dbContext.GetCollection<Engine>("Engine");
        }
    }
}
