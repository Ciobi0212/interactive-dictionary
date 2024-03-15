using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Exersare.Classes
{
    public static class GameState
    {
        public static void newWords()
        {
            // Get 5 random words from the list of words and put them in the guessingWords list
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(ApplicationState.words.Count);
                guessingWords.Add(ApplicationState.words[index]);
            }
        }

        public static void advanceGame(string guess) 
        {
            if (isGuessCorrect(guess))
            {
                score++;
            }

            if (indexOfWord == guessingWords.Count - 1)
            {
                isGameFinished = true;
                MessageBox.Show("Game finished! Your score is: " + score);
            }

            else
            {

                currentWord = guessingWords[++indexOfWord];

                Random random = new Random();
                bool hasNoImg = currentWord.ImagePath == "E:\\repos\\interactive-dictionary\\WordImages\\noimg.png";
                showImage = hasNoImg == false ? random.Next(0,2) == 1 : false;
                showedImages.Add(showImage);
            }
        }

        public static bool goBack()
        {
            if (indexOfWord > 0)
            {
                indexOfWord--;
                score = score == 0 ? 0 : score-1;
                currentWord = guessingWords[indexOfWord];
                showImage = showedImages[indexOfWord];
                return true;
            }

            return false;
        }

        public static bool isGuessCorrect(string guess)
        {
            if(guess == null)
            {
                return false;
            }

            if (guessingWords[indexOfWord].Name.ToLower() == guess.ToLower())
            {
                return true;
            }

            return false;
        }   

        public static bool isOnLastWord()
        {
            return indexOfWord == guessingWords.Count - 1;
        }

        public static void resetGame()
        {
            score = 0;
            indexOfWord = -1;
            guessingWords.Clear();
            isGameFinished = false;
            showImage = false;
            showedImages.Clear();
            currentWord = null;
        }

        public static List<Word> guessingWords = new List<Word>();
        public static Word currentWord = new Word();
        public static int score = 0;
        public static int indexOfWord = -1;
        public static List<bool> showedImages = new List<bool>();
        public static bool isGameFinished = false;
        public static bool showImage = false;
    }
}
