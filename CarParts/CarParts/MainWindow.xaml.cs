using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using CarParts.DataModels;
using CarParts.Pages;

namespace CarParts
{
    public partial class MainWindow : Window
    {
        public MongoClient dbClient { get; set; }
        public IMongoDatabase dbContext { get; set; }
        public IMongoCollection<Car> Cars { get; set; }
        public IMongoCollection<Engine> EngineParts { get; set; }
        public IMongoCollection<Suspension> SuspensionParts { get; set; }
        public IMongoCollection<Wheel> Wheels { get; set; }
        public IMongoCollection<Client> Clients { get; set; }

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

            MainMenu Menu = new MainMenu();
            this.Content = Menu;
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
