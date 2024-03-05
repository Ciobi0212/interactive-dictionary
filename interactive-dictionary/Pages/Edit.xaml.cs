using Exersare.Classes;
using Microsoft.Win32;
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
    public partial class EditWord : Page
    {
        public EditWord()
        {
            InitializeComponent();

            imgEdit.DataContext = ApplicationState.selectedWord;
            editField.DataContext = ApplicationState.selectedWord;
            cmbEditCategory.ItemsSource = ApplicationState.categoriesNames;
            cmbEditCategory.SelectedItem = ApplicationState.selectedWord.CategoryName;

            if (ApplicationState.isAdding)
            {
                btnAddImage.Visibility = Visibility.Visible;
                cmbEditCategory.SelectedItem = null;
            }

            else
            {
                btnAddImage.Visibility = Visibility.Hidden;
                imgEdit.Visibility = Visibility.Visible;
                
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Add new category if it doesn't exist and set CategoryName to the selected word
            if (cmbEditCategory.SelectedItem == null) 
            {
                ApplicationState.categoriesMap.Add(txtNewCategory.Text, new List<Word>());
                ApplicationState.categoriesNames.Add(txtNewCategory.Text);
                ApplicationState.selectedWord.CategoryName = txtNewCategory.Text;
            }

            // Category already exists, set CategoryName to the selected word
            else
            {
                ApplicationState.selectedWord.CategoryName = cmbEditCategory.SelectedItem.ToString();
            }

            // If the word is being added, add it to the list of words and the category
            if(ApplicationState.isAdding)
            {
                ApplicationState.words.Add(ApplicationState.selectedWord);

                ApplicationState.categoriesMap[ApplicationState.selectedWord.CategoryName].Add(ApplicationState.selectedWord);
                ApplicationState.categoriesMap["All"].Add(ApplicationState.selectedWord);

                ApplicationState.isAdding = false;
            }

            MessageBox.Show("Word updated successfully!");

            //Save the changes to the JSON file
            ApplicationState.saveData();

            // Navigate back to the Dictionary page
            this.NavigationService.Navigate(new Uri("Pages/Dictionary.xaml", UriKind.Relative));
            
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ApplicationState.selectedWord.ImagePath = openFileDialog.FileName;
            }

            if(ApplicationState.selectedWord.ImagePath != null)
            {
                //btnAddImage.Visibility = Visibility.Hidden;
                imgEdit.Source = new BitmapImage(new Uri(ApplicationState.selectedWord.ImagePath));
                imgEdit.Visibility = Visibility.Visible;
            }
        }

        private void txtNewCategory_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtNewCategory.Text.Length == 0)
            {
               
                cmbEditCategory.Visibility = Visibility.Visible;
                lbEditCategory.Visibility = Visibility.Visible;
                return;
            }

            cmbEditCategory.SelectedItem = null;
            cmbEditCategory.Visibility = Visibility.Hidden;
            lbEditCategory.Visibility = Visibility.Hidden;
        }
    }
}
