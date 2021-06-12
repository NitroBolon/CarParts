using CarParts.DataModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarParts.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Catalog.xaml
    /// </summary>
    public partial class Add : Page
    {
        MainWindow wnd;

        public Add()
        {
            InitializeComponent();
            wnd = (MainWindow)App.Current.MainWindow;

            Epurpose.ItemsSource = wnd.Purpose;
            Spurpose.ItemsSource = wnd.Purpose;

            Epurpose.SelectedItem = wnd.Purpose[0];
            Spurpose.SelectedItem = wnd.Purpose[0];

            RefreshLists();
        }

        private void RefreshLists()
        {
            Ccar.ItemsSource = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu men = new MainMenu();
            wnd.Content = men;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wnd.Title = "CarParts: Dodaj";
        }

        private void Wheel_Click(object sender, RoutedEventArgs e)
        {
            var make = Wmake.Text;
            var modell = Wmodel.Text;
            var diam = Wdiameter.Text;
            var pric = Wprice.Text;
            var vins = Wvin.Text;
            int diameter1 = 0, price1 = 0;

            if(!Int32.TryParse(diam, out diameter1) || !Int32.TryParse(pric, out price1))
            {
                MessageBox.Show("Podano złe dane liczbowe (średnica/cena)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(modell))
            {
                MessageBox.Show("Brak wymaganych danych (producent/model)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Wheel newWheel = new Wheel
            {
                name = make,
                model = modell,
                diameter = diameter1,
                vin = vins,
                price = price1
            };

            wnd.Wheels.InsertOne(newWheel);

            MessageBox.Show("Dodano obiekt do bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Wmake.Text = string.Empty;
            Wmodel.Text = string.Empty;
            Wdiameter.Text = string.Empty;
            Wprice.Text = string.Empty;
            Wvin.Text = string.Empty;

            return;
        }

        private void Engine_Click(object sender, RoutedEventArgs e)
        {
            var make = Emake.Text;
            var modell = Emodel.Text;
            var purp = Epurpose.SelectedItem.ToString();
            var pric = Eprice.Text;
            var vins = Evin.Text;
            int price1 = 0;

            if (!Int32.TryParse(pric, out price1))
            {
                MessageBox.Show("Podano złe dane liczbowe (cena)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(modell))
            {
                MessageBox.Show("Brak wymaganych danych (producent/model)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Engine newWheel = new Engine
            {
                name = make,
                model = modell,
                purpose = purp,
                vin = vins,
                price = price1
            };

            wnd.EngineParts.InsertOne(newWheel);

            MessageBox.Show("Dodano obiekt do bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Emake.Text = string.Empty;
            Emodel.Text = string.Empty;
            Eprice.Text = string.Empty;
            Evin.Text = string.Empty;

            return;
        }

        private void Suspension_Click(object sender, RoutedEventArgs e)
        {
            var make = Smake.Text;
            var modell = Smodel.Text;
            var purp = Spurpose.SelectedItem.ToString();
            var pric = Sprice.Text;
            var vins = Svin.Text;
            int price1 = 0;

            if (!Int32.TryParse(pric, out price1))
            {
                MessageBox.Show("Podano złe dane liczbowe (cena)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(modell))
            {
                MessageBox.Show("Brak wymaganych danych (producent/model)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Suspension newWheel = new Suspension
            {
                name = make,
                model = modell,
                purpose = purp,
                vin = vins,
                price = price1
            };

            wnd.SuspensionParts.InsertOne(newWheel);

            MessageBox.Show("Dodano obiekt do bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Smake.Text = string.Empty;
            Smodel.Text = string.Empty;
            Sprice.Text = string.Empty;
            Svin.Text = string.Empty;

            return;
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            var name = Cname.Text;
            var addr = Caddress.Text;
            var ccar = (Car)Ccar.SelectedItem;
            string car = "";
            if (ccar != null)
            { 
                car = ccar.carId;
            } 
            var phon = Cphone.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phon))
            {
                MessageBox.Show("Brak wymaganych danych (Imię i nazwisko/kontakt)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Client newWheel = new Client
            {
                name = name,
                address = addr,
                car = car,
                phone = phon
            };

            wnd.Clients.InsertOne(newWheel);

            MessageBox.Show("Dodano obiekt do bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Cname.Text = string.Empty;
            Caddress.Text = string.Empty;
            Cphone.Text = string.Empty;

            return;
        }

        private void Car_Click(object sender, RoutedEventArgs e)
        {
            var make = Cmake.Text;
            var modell = Cmodel.Text;
            var year = Cyear.Text;
            var vins = Cvin.Text;
            int price1 = 0;

            if (!Int32.TryParse(year, out price1))
            {
                MessageBox.Show("Podano złe dane liczbowe (rok)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(modell) || string.IsNullOrWhiteSpace(vins))
            {
                MessageBox.Show("Brak wymaganych danych (producent/model/VIN)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string maxId = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result.Select(c => c.carId).OrderByDescending(cv => cv).FirstOrDefault();
            var vinns = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result.Select(c => c.vin);
            int maxInt = Int32.Parse(maxId) + 1;

            if (vinns.Contains(vins))
            {
                MessageBox.Show("Auto o podanym VIN już istnieje", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Car newWheel = new Car
            {
                name = make,
                model = modell,
                carId = maxInt.ToString(),
                vin = vins,
                year = price1
            };

            wnd.Cars.InsertOne(newWheel);

            MessageBox.Show("Dodano obiekt do bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Cmake.Text = string.Empty;
            Cmodel.Text = string.Empty;
            Cyear.Text = string.Empty;
            Cvin.Text = string.Empty;

            RefreshLists();

            return;
        }
    }
}
