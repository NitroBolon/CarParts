using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using CarParts.DataModels;

namespace CarParts.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        MainWindow wnd;

        public Catalog()
        {
            InitializeComponent();
            wnd = (MainWindow)App.Current.MainWindow;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu men = new MainMenu();
            wnd.Content = men;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wnd.Title = "CarParts: Katalog";

            var wheelsContent = string.Empty;
            var engineContent = string.Empty;
            var suspensionContent = string.Empty;
            var clientContent = string.Empty;
            var carsContent = string.Empty;

            var carList = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result;
            var engineList = wnd.EngineParts.Find(new BsonDocument()).ToListAsync().Result;
            var suspensionList = wnd.SuspensionParts.Find(new BsonDocument()).ToListAsync().Result;
            var clientList = wnd.Clients.Find(new BsonDocument()).ToListAsync().Result;
            var wheelList = wnd.Wheels.Find(new BsonDocument()).ToListAsync().Result;

            foreach(var x in carList)
            {
                var vin = x.carId;
                var owner = clientList.Where(c => c.car.Contains(vin)).FirstOrDefault();

                carsContent += $"{x.name} {x.model}\n{x.year}, {owner.name}\n\n";
            }

            foreach (var x in clientList)
            {
                clientContent += $"{x.name}\n{x.address}\n{x.phone}\n\n";
            }

            foreach (var x in engineList)
            {
                engineContent += $"{x.name} {x.model}\n{x.purpose} - {x.price}zł/szt\n\n";
            }

            foreach (var x in suspensionList)
            {
                suspensionContent += $"{x.name} {x.model}\n{x.purpose} - {x.price}zł/szt\n\n";
            }

            foreach (var x in wheelList)
            {
                wheelsContent += $"{x.name} {x.model}\n{x.diameter}inch - {x.price}zł/szt\n\n";
            }

            clientsCarsList.Text = carsContent;
            clientsList.Text = clientContent;
            enginesList.Text = engineContent;
            wheelsList.Text = wheelsContent;
            suspensionsList.Text = suspensionContent;
        }
    }
}
