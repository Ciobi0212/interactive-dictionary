﻿using System;
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
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the RightsSelection page
            this.NavigationService.Navigate(new Uri("Pages/RightsSelection.xaml", UriKind.Relative));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;

            foreach(var admin in ApplicationState.admins)
            {
                if(admin.Username == tbUsername.Text && admin.Password == tbPassword.Password)
                {
                    ApplicationState.isAdmin = true;
                    this.NavigationService.Navigate(new Uri("Pages/Dictionary.xaml", UriKind.Relative));
                    found = true;
                    break;
                }
            }

            if(!found)
            {
                MessageBox.Show("Incorrect credentials! Please try again.");
                ApplicationState.isAdmin = false;
            }

            
        }
    }
}
