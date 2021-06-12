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
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Window wnd;

        public MainMenu()
        {
            InitializeComponent();
            wnd = (MainWindow)App.Current.MainWindow;
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            Catalog ctl = new Catalog();
            wnd.Content = ctl;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            wnd.Content = add;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete del = new Delete();
            wnd.Content = del;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update upd = new Update();
            wnd.Content = upd;
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            Clients cli = new Clients();
            wnd.Content = cli;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wnd.Title = "CarParts: Menu";
        }
    }
}
