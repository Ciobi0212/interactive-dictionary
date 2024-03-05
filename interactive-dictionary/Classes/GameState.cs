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
                currentWord = guessingWords[indexOfWord];
                indexOfWord++;
                

                Random random = new Random();
                showImage = random.Next(0, 2) == 1;
            }

        }

        public static bool goBack()
        {
            if (indexOfWord > 0)
            {
                currentWord = guessingWords[indexOfWord];
                indexOfWord--;
                score--;
                return true;
            }

            return false;
        }

        public static bool isGuessCorrect(string guess)
        {
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
            indexOfWord = 0;
            guessingWords.Clear();
            isGameFinished = false;
        }

        public static List<Word> guessingWords = new List<Word>();
        public static Word currentWord = new Word();
        public static int score = 0;
        public static int indexOfWord = 0;
        public static bool isGameFinished = false;
        public static bool showImage = false;
    }
}
