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
    public partial class Delete : Page
    {
        MainWindow wnd;

        public Delete()
        {
            InitializeComponent();
            wnd = (MainWindow)App.Current.MainWindow;

            RefreshLists();
        }

        private void RefreshLists()
        {
            Wmake.ItemsSource = wnd.Wheels.Find(new BsonDocument()).ToListAsync().Result;
            Emake.ItemsSource = wnd.EngineParts.Find(new BsonDocument()).ToListAsync().Result;
            Smake.ItemsSource = wnd.SuspensionParts.Find(new BsonDocument()).ToListAsync().Result;
            Cmake.ItemsSource = wnd.Cars.Find(new BsonDocument()).ToListAsync().Result;
            Cname.ItemsSource = wnd.Clients.Find(new BsonDocument()).ToListAsync().Result;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu men = new MainMenu();
            wnd.Content = men;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wnd.Title = "CarParts: Usuń";
        }

        private void Wheel_Click(object sender, RoutedEventArgs e)
        {
            var item = (Wheel)Wmake.SelectedItem;
            
            if(item == null)
            {
                MessageBox.Show("Wybierz obiekt do usunięcia", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var deleteFilter = Builders<Wheel>.Filter.Eq("_id", item._id);

            wnd.Wheels.DeleteOne(deleteFilter);

            MessageBox.Show("Obiekt usunięty z bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            RefreshLists();
        }

        private void Engine_Click(object sender, RoutedEventArgs e)
        {
            var item = (Engine)Emake.SelectedItem;

            if (item == null)
            {
                MessageBox.Show("Wybierz obiekt do usunięcia", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var deleteFilter = Builders<Engine>.Filter.Eq("_id", item._id);

            wnd.EngineParts.DeleteOne(deleteFilter);

            MessageBox.Show("Obiekt usunięty z bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            RefreshLists();
        }

        private void Suspension_Click(object sender, RoutedEventArgs e)
        {
            var item = (Suspension)Smake.SelectedItem;

            if (item == null)
            {
                MessageBox.Show("Wybierz obiekt do usunięcia", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var deleteFilter = Builders<Suspension>.Filter.Eq("_id", item._id);

            wnd.SuspensionParts.DeleteOne(deleteFilter);

            MessageBox.Show("Obiekt usunięty z bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            RefreshLists();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            var item = (Client)Cname.SelectedItem;

            if (item == null)
            {
                MessageBox.Show("Wybierz obiekt do usunięcia", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var deleteFilter = Builders<Client>.Filter.Eq("_id", item._id);

            wnd.Clients.DeleteOne(deleteFilter);

            MessageBox.Show("Obiekt usunięty z bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            RefreshLists();
        }

        private void Car_Click(object sender, RoutedEventArgs e)
        {
            var item = (Car)Cmake.SelectedItem;

            if (item == null)
            {
                MessageBox.Show("Wybierz obiekt do usunięcia", "CarParts: Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var deleteFilter = Builders<Car>.Filter.Eq("_id", item._id);

            wnd.Cars.DeleteOne(deleteFilter);

            MessageBox.Show("Obiekt usunięty z bazy", "CarParts: Success", MessageBoxButton.OK, MessageBoxImage.Information);

            RefreshLists();
        }
    }
}
