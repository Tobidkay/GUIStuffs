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

namespace Opgave1.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
        }

        private void BuyMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BuyMenu());
        }

        private void ProductMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProductManagement());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
