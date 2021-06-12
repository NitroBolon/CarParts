using CarParts.DataModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarParts.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Catalog.xaml
    /// </summary>
    public partial class Update : Page
    {
        MainWindow wnd;

        public Update()
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
            Wcb.ItemsSource = wnd.Wheels.Find(new BsonDocument()).ToListAsync().Result;
            Ecb.ItemsSource = wnd.EngineParts.Find(new BsonDocument()).ToListAsync().Result;
            Scb.ItemsSource = wnd.SuspensionParts.Find(new BsonDocument()).ToListAsync().Result;
            Ccb.ItemsSource = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result;
            Clcb.ItemsSource = wnd.Clients.Find(new BsonDocument()).ToListAsync().Result;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu men = new MainMenu();
            wnd.Content = men;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wnd.Title = "CarParts: Aktualizuj";
        }

        private void Wheel_Click(object sender, RoutedEventArgs e)
        {
            var make = Wmake.Text;
            var modell = Wmodel.Text;
            var diam = Wdiameter.Text;
            var pric = Wprice.Text;
            var vins = Wvin.Text;
            int diameter1 = 0, price1 = 0;
            var item = (Wheel)Wcb.SelectedItem;

            if(item == null)
            {
                MessageBox.Show("Nie wybrano obiektu", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Int32.TryParse(diam, out diameter1) || !Int32.TryParse(pric, out price1))
            {
                MessageBox.Show("Podano złe dane liczbowe (średnica/cena)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(modell))
            {
                MessageBox.Show("Brak wymaganych danych (producent/model)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var updateFilter = Builders<Wheel>.Filter.Eq("_id", item._id);
            var updater = Builders<Wheel>.Update.Set("name", make);
            wnd.Wheels.UpdateOne(updateFilter, updater);
            updater = Builders<Wheel>.Update.Set("model", modell);
            wnd.Wheels.UpdateOne(updateFilter, updater);
            updater = Builders<Wheel>.Update.Set("diameter", diameter1);
            wnd.Wheels.UpdateOne(updateFilter, updater);
            updater = Builders<Wheel>.Update.Set("vin", vins);
            wnd.Wheels.UpdateOne(updateFilter, updater);
            updater = Builders<Wheel>.Update.Set("price", price1);
            wnd.Wheels.UpdateOne(updateFilter, updater);

            MessageBox.Show("Zaktualizowano obiekt w bazie", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Ccb.SelectedItem = null;
            Wmake.Text = string.Empty;
            Wmodel.Text = string.Empty;
            Wdiameter.Text = string.Empty;
            Wprice.Text = string.Empty;
            Wvin.Text = string.Empty;

            RefreshLists();

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
            var item = (Engine)Ecb.SelectedItem;

            if (item == null)
            {
                MessageBox.Show("Nie wybrano obiektu", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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

            var updateFilter = Builders<Engine>.Filter.Eq("_id", item._id);
            var updater = Builders<Engine>.Update.Set("name", make);
            wnd.EngineParts.UpdateOne(updateFilter, updater);
            updater = Builders<Engine>.Update.Set("model", modell);
            wnd.EngineParts.UpdateOne(updateFilter, updater);
            updater = Builders<Engine>.Update.Set("purpose", purp);
            wnd.EngineParts.UpdateOne(updateFilter, updater);
            updater = Builders<Engine>.Update.Set("vin", vins);
            wnd.EngineParts.UpdateOne(updateFilter, updater);
            updater = Builders<Engine>.Update.Set("price", price1);
            wnd.EngineParts.UpdateOne(updateFilter, updater);

            MessageBox.Show("Zaktualizowano obiekt w bazie", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Ecb.SelectedItem = null;
            Emake.Text = string.Empty;
            Emodel.Text = string.Empty;
            Eprice.Text = string.Empty;
            Evin.Text = string.Empty;

            RefreshLists();

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
            var item = (Suspension)Scb.SelectedItem;

            if (item == null)
            {
                MessageBox.Show("Nie wybrano obiektu", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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

            var updateFilter = Builders<Suspension>.Filter.Eq("_id", item._id);
            var updater = Builders<Suspension>.Update.Set("name", make);
            wnd.SuspensionParts.UpdateOne(updateFilter, updater);
            updater = Builders<Suspension>.Update.Set("model", modell);
            wnd.SuspensionParts.UpdateOne(updateFilter, updater);
            updater = Builders<Suspension>.Update.Set("purpose", purp);
            wnd.SuspensionParts.UpdateOne(updateFilter, updater);
            updater = Builders<Suspension>.Update.Set("vin", vins);
            wnd.SuspensionParts.UpdateOne(updateFilter, updater);
            updater = Builders<Suspension>.Update.Set("price", price1);
            wnd.SuspensionParts.UpdateOne(updateFilter, updater);

            MessageBox.Show("Zaktualizowano obiekt w bazie", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Scb.SelectedItem = null;
            Smake.Text = string.Empty;
            Smodel.Text = string.Empty;
            Sprice.Text = string.Empty;
            Svin.Text = string.Empty;

            RefreshLists();

            return;
        }

        private void Car_Click(object sender, RoutedEventArgs e)
        {
            var make = Cmake.Text;
            var modell = Cmodel.Text;
            var year = Cyear.Text;
            var vins = Cvin.Text;
            int price1 = 0;
            var item = (Car)Ccb.SelectedItem;

            if (item == null)
            {
                MessageBox.Show("Nie wybrano obiektu", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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

            var updateFilter = Builders<Car>.Filter.Eq("_id", item._id);
            var updater = Builders<Car>.Update.Set("name", make);
            wnd.Cars.UpdateOne(updateFilter, updater);
            updater = Builders<Car>.Update.Set("model", modell);
            wnd.Cars.UpdateOne(updateFilter, updater);
            updater = Builders<Car>.Update.Set("vin", vins);
            wnd.Cars.UpdateOne(updateFilter, updater);
            updater = Builders<Car>.Update.Set("year", year);
            wnd.Cars.UpdateOne(updateFilter, updater);

            MessageBox.Show("Zaktualizowano obiekt w bazie", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Ccb.SelectedItem = null;
            Cmake.Text = string.Empty;
            Cmodel.Text = string.Empty;
            Cyear.Text = string.Empty;
            Cvin.Text = string.Empty;

            RefreshLists();

            return;
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            var name = Cname.Text;
            var addr = Caddress.Text;
            var item = (Client)Clcb.SelectedItem;
            var phon = Cphone.Text;

            if (item == null)
            {
                MessageBox.Show("Nie wybrano obiektu", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phon))
            {
                MessageBox.Show("Brak wymaganych danych (Imię i nazwisko/kontakt)", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var updateFilter = Builders<Client>.Filter.Eq("_id", item._id);
            var updater = Builders<Client>.Update.Set("name", name);
            wnd.Clients.UpdateOne(updateFilter, updater);
            updater = Builders<Client>.Update.Set("address", addr);
            wnd.Clients.UpdateOne(updateFilter, updater);
            updater = Builders<Client>.Update.Set("phone", phon);
            wnd.Clients.UpdateOne(updateFilter, updater);

            MessageBox.Show("Zaktualizowano obiekt w bazie", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Clcb.SelectedItem = null;
            Cname.Text = string.Empty;
            Caddress.Text = string.Empty;
            Cphone.Text = string.Empty;

            carToAdd.ItemsSource = null;
            carToDel.ItemsSource = null;
            RefreshLists();

            return;
        }

        private void DelCar_Click(object sender, RoutedEventArgs e)
        {
            var item = (Client)Clcb.SelectedItem;
            var car = (Car)carToDel.SelectedItem;

            if (item != null && car != null)
            {
                List<Car> userCarsParsed = new List<Car>();
                List<string> userParsed = new List<string>();
                if (!string.IsNullOrEmpty(item.car))
                {
                    var carsParsed = item.car.Split(',').ToList();

                    foreach (var x in carsParsed)
                    {
                        var carFilter = Builders<Car>.Filter.Eq("carId", x);
                        if (!x.Equals(car.carId))
                        {
                            userCarsParsed.Add(wnd.Cars.Find(carFilter).FirstOrDefault());
                            userParsed.Add(x);
                        }
                    }

                    UpdateUserCarsDropdowns(userCarsParsed);
                }

                var updateFilter = Builders<Client>.Filter.Eq("_id", item._id);
                var updater = Builders<Client>.Update.Set("car", string.Join(",", userParsed));

                wnd.Clients.UpdateOne(updateFilter, updater);
            }
            else
            {
                MessageBox.Show("Nie wybrano obiektów", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var item = (Client)Clcb.SelectedItem;
            var car = (Car)carToAdd.SelectedItem;

            if(item != null && car != null)
            {
                var updateFilter = Builders<Client>.Filter.Eq("_id", item._id);
                var updater = Builders<Client>.Update.Set("car", $"{item.car},{car.carId}");

                wnd.Clients.UpdateOne(updateFilter, updater);

                var newCar = wnd.Clients.Find(updateFilter).FirstOrDefault().car;

                List<Car> userCarsParsed = new List<Car>();
                if (!string.IsNullOrEmpty(newCar))
                {
                    var carsParsed = item.car.Split(',').ToList();

                    foreach (var x in carsParsed)
                    {
                        var carFilter = Builders<Car>.Filter.Eq("carId", x);
                        userCarsParsed.Add(wnd.Cars.Find(carFilter).FirstOrDefault());
                    }

                    userCarsParsed.Add(car);

                    UpdateUserCarsDropdowns(userCarsParsed);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano obiektów", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Wcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Wheel)Wcb.SelectedItem;

            if(item != null)
            {
                Wmake.Text = item.name;
                Wmodel.Text = item.model;
                Wprice.Text = item.price.ToString();
                Wdiameter.Text = item.diameter.ToString();
                Wvin.Text = item.vin;
            }
        }

        private void Ecb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Engine)Ecb.SelectedItem;

            if (item != null)
            {
                Emake.Text = item.name;
                Emodel.Text = item.model;
                Eprice.Text = item.price.ToString();
                Epurpose.Text = item.purpose.ToString();
                Evin.Text = item.vin;
            }
        }

        private void Scb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Suspension)Scb.SelectedItem;

            if (item != null)
            {
                Smake.Text = item.name;
                Smodel.Text = item.model;
                Sprice.Text = item.price.ToString();
                Spurpose.Text = item.purpose.ToString();
                Svin.Text = item.vin;
            }
        }

        private void Clcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Client)Clcb.SelectedItem;

            if (item != null)
            {
                Cname.Text = item.name;
                Caddress.Text = item.address;
                Cphone.Text = item.phone;

                List<Car> userCarsParsed = new List<Car>();
                if(!string.IsNullOrEmpty(item.car))
                {
                    var carsParsed = item.car.Split(',').ToList();

                    foreach(var x in carsParsed)
                    {
                        var carFilter = Builders<Car>.Filter.Eq("carId", x);
                        userCarsParsed.Add(wnd.Cars.Find(carFilter).FirstOrDefault());
                    }

                    UpdateUserCarsDropdowns(userCarsParsed);
                }
            }
        }

        private void Ccb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Car)Ccb.SelectedItem;

            if (item != null)
            {
                Cmake.Text = item.name;
                Cmodel.Text = item.model;
                Cvin.Text = item.vin;
                Cyear.Text = item.year.ToString();
            }
        }

        private void UpdateUserCarsDropdowns(List<Car> owned = null)
        {
            if(owned != null)
                carToDel.ItemsSource = owned;
            carToAdd.ItemsSource = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result;
        }
    }
}
