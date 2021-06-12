using CarParts.DataModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarParts.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Catalog.xaml
    /// </summary>
    public partial class Clients : Page
    {
        MainWindow wnd;

        public Clients()
        {
            InitializeComponent();
            wnd = (MainWindow)App.Current.MainWindow;

            Cli.ItemsSource = wnd.Clients.Find(new BsonDocument()).ToListAsync().Result;
            Car.ItemsSource = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu men = new MainMenu();
            wnd.Content = men;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wnd.Title = "CarParts: Propozycje";
        }

        private void Cli_Click(object sender, RoutedEventArgs e)
        {
            var res = "";
            var item = (Client)Cli.SelectedItem;
            if(item != null)
            {
                var cars = item.car.Split(',');

                foreach(var x in cars)
                {
                    var carFilter = Builders<Car>.Filter.Eq("carId", x);
                    var car = wnd.Cars.Find(carFilter).FirstOrDefault();
                    res += $"Części do {car.name} {car.model}:\n";
                    res += $"{CarProducts(car.vin)}\n";
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano obiektu", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            resCli.Text = res;
        }

        private void Car_Click(object sender, RoutedEventArgs e)
        {
            var res = "";
            var item = (Car)Car.SelectedItem;
            if (item != null)
            {
                var vin = item.vin;

                res += CarProducts(vin);
            }
            else
            {
                MessageBox.Show("Nie wybrano obiektu", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            resCar.Text = res;
        }

        private string CarProducts(string vin)
        {
            string res = "";

            var wheelFilter = Builders<Wheel>.Filter.Regex("vin", new BsonRegularExpression($".*{vin}.*"));
            var susFilter = Builders<Suspension>.Filter.Regex("vin", new BsonRegularExpression($".*{vin}.*"));
            var engFilter = Builders<Engine>.Filter.Regex("vin", new BsonRegularExpression($".*{vin}.*"));

            var wheels = wnd.Wheels.Find(wheelFilter).ToList();
            var suspensions = wnd.SuspensionParts.Find(susFilter).ToList();
            var engines = wnd.EngineParts.Find(engFilter).ToList();

            res += "Felgi:\n";
            foreach(var x in wheels)
            {
                res += $"{x.name} {x.model} - {x.diameter}\" - {x.price}PLN\n";
            }

            res += "\nCzęści zawieszenia:\n";
            foreach (var x in suspensions)
            {
                res += $"{x.name} {x.model} - {x.purpose} - {x.price}PLN\n";
            }

            res += "\nCzęści do silnika:\n";
            foreach (var x in engines)
            {
                res += $"{x.name} {x.model} - {x.purpose} - {x.price}PLN\n";
            }

            return res;
        }
    }
}
