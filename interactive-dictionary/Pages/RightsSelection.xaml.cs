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

namespace Exersare.Pages
{
    /// <summary>
    /// Interaction logic for RightsSelection.xaml
    /// </summary>
    public partial class RightsSelection : Page
    {
        public RightsSelection()
        {
            InitializeComponent();
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Login page
            this.NavigationService.Navigate(new Uri("Pages/Login.xaml", UriKind.Relative));
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Dictionary Page
            this.NavigationService.Navigate(new Uri("Pages/Dictionary.xaml", UriKind.Relative));
        }
    }
}
