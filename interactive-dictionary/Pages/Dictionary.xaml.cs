using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            suggestionsBox.ItemsSource = ApplicationState.suggestedWords;

            cbCategory.ItemsSource = ApplicationState.categoriesNames;
            cbCategory.SelectedItem = "All";

            if(ApplicationState.isAdmin)
            {
                adminMode.Visibility = Visibility.Visible;
            }
        }

        public void getRecommandations(string input, string categoryName)
        {
            ApplicationState.suggestedWords.Clear();

            foreach (var word in ApplicationState.categoriesMap[categoryName])
            {
                if (word.Name.ToLower().StartsWith(input))
                {
                    ApplicationState.suggestedWords.Add(word);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the RightsSelection page
            this.NavigationService.Navigate(new Uri("Pages/RightsSelection.xaml", UriKind.Relative));
        }

        private void txSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txSearchBox.Text.Length == 0)
            {
                suggestionsBox.Visibility = Visibility.Hidden;
                return;
            }

           getRecommandations(txSearchBox.Text, cbCategory.Text);
           suggestionsBox.Visibility = Visibility.Visible;
        }

        private void suggestionsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(suggestionsBox.SelectedItem == null)
            {
                return;
            }

            ApplicationState.selectedWord = suggestionsBox.SelectedItem as Word;
            wordInfo.DataContext = ApplicationState.selectedWord;
            suggestionsBox.Visibility = Visibility.Hidden;
            if(ApplicationState.isAdmin)
            {
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationState.selectedWord = new Word();
            ApplicationState.isAdding = true;
            this.NavigationService.Navigate(new Uri("Pages/Edit.xaml", UriKind.Relative));
        }

        private void EditWordButton_Click(object sender, RoutedEventArgs e)
        {
            if(ApplicationState.selectedWord.Name == "")
            {
                MessageBox.Show("Please select a word to edit!");
                return;
            }

            this.NavigationService.Navigate(new Uri("Pages/Edit.xaml", UriKind.Relative));
        }

        private void DeleteWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Pop up a message box to confirm the deletion
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this word?", "Confirmation", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                //Remove the word from the list of words and the category
                ApplicationState.words.Remove(ApplicationState.selectedWord);
                ApplicationState.categoriesMap[ApplicationState.selectedWord.CategoryName].Remove(ApplicationState.selectedWord);
                ApplicationState.categoriesMap["All"].Remove(ApplicationState.selectedWord);

                // Save the changes to the JSON file
                ApplicationState.saveData();

                // Update the UI
                MessageBox.Show("Word deleted successfully!");
                ApplicationState.selectedWord = null;
                wordInfo.Visibility = Visibility.Hidden;
            }
        }
    }
}
