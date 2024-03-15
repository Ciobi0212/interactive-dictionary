using Exersare.Classes;
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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();

            // Set the DataContext of the page to the ApplicationState
            GameState.newWords();
            GameState.advanceGame(null);

            this.DataContext = GameState.currentWord;

            if (GameState.showImage)
            {
                imgWord.Visibility = Visibility.Visible;
                descWord.Visibility = Visibility.Collapsed;

            }
            else
            {
                imgWord.Visibility = Visibility.Collapsed;
                descWord.Visibility = Visibility.Visible;
            }
        }

        private void showWordInfo()
        {
            this.DataContext = GameState.currentWord;

            if (GameState.showImage)
            {
                imgWord.Visibility = Visibility.Visible;
                descWord.Visibility = Visibility.Collapsed;

            }
            else
            {
                imgWord.Visibility = Visibility.Collapsed;
                descWord.Visibility = Visibility.Visible;
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            GameState.advanceGame(txGuessWord.Text.ToString());

            if(GameState.isOnLastWord())
            {
                btnNext_Finish.Content = "Finish";
            }

            if(GameState.isGameFinished)
            {
                this.NavigationService.Navigate(new Uri("Pages/RightsSelection.xaml", UriKind.Relative));
                GameState.resetGame();
            }

            showWordInfo();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.goBack() == false)
            {
                this.NavigationService.Navigate(new Uri("Pages/RightsSelection.xaml", UriKind.Relative));
                GameState.resetGame();
            }

            showWordInfo();
            btnNext_Finish.Content = "Next";
        }
    }
}
