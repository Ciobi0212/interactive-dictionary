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
using Exersare.Classes;

namespace Exersare.Pages
{
    public partial class Dictionary : Page
    {
        public Dictionary()
        {
            InitializeComponent();

            if(ApplicationState.isAdmin)
            {
                adminMode.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the RightsSelection page
            this.NavigationService.Navigate(new Uri("Pages/RightsSelection.xaml", UriKind.Relative));
        }
    }
}
