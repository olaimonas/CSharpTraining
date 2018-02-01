using System;
using System.Collections.Generic;
using System.IO;
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

namespace HangMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<char> guessedLetters = new List<char>();
        private String secretWord;
        private int triesLeft = 6;

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] words = File.ReadAllLines("words.txt");

            Random random = new Random();
            int randomIndex = random.Next(0, words.Length - 1);
            secretWord = words[randomIndex];

            secretWordLbl.Content = MaskWord(secretWord, guessedLetters);
        }

        private String MaskWord(String secretWord, List<char> letters)
        {
            String maskedWord = "";
            foreach (char letter in secretWord)
            {
                if (letters.Contains(letter))
                {
                    maskedWord += letter;
                }
                else
                {
                    maskedWord += "__" + " ";
                }
            }
            return maskedWord;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            char letter = e.Key.ToString().ToLower()[0];
            bool correctLetter = secretWord.Contains(letter);

            if (correctLetter && !guessedLetters.Contains(letter))
            {

                guessedLetters.Add(letter);

                String maskedWord = MaskWord(secretWord, guessedLetters);
                secretWordLbl.Content = maskedWord;
                if (maskedWord.Replace(" ", "") == secretWord)
                {
                    winLoseLbl.Content = "You won!";
                }

            }
            if(!correctLetter)
            {
                triesLeft -= 1;
                tryCountLbl.Content = triesLeft;

                if(triesLeft == 0)
                {
                    winLoseLbl.Content = "You lose!";
                }
            }
        }
    }
}
