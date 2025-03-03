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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowResume_Click(object sender, RoutedEventArgs e)
        {
            string[] resume = new string[]
            {
                "Name: Danil",
                "Age: 18",
                "Country: Russia",
                "Skills: C++, C#, Dart Flutter, PostgreSQL",
                "Hobbies: Programming, Reading, Gaming"
            };

            int totalChars = resume.Sum(k => k.Length);
            int avgChars = totalChars / resume.Length;

            for (int i = 0; i < resume.Length; i++)
            {
                string title = i == resume.Length - 1 ? $"Avg Chars: {avgChars}" : $"Line {i + 1}";
                MessageBox.Show(resume[i], title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GuessNumber_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            while (true)
            {
                int min = 1, max = 2000, attempts = 0;
                MessageBox.Show("Think of a number from 1 to 2000, and I will try to guess it!", "Game Start", MessageBoxButton.OK, MessageBoxImage.Information);

                while (min <= max)
                {
                    int guess = random.Next(min, max + 1);
                    attempts++;

                    MessageBoxResult response = MessageBox.Show($"Is your number {guess}?", "Attempt #" + attempts, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                    if (response == MessageBoxResult.Yes)
                    {
                        MessageBox.Show($"I guessed your number {guess} in {attempts} attempts!", "Victory!", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Game interrupted.", "Exit", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                MessageBoxResult playAgain = MessageBox.Show("Do you want to play again?", "Game Over", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (playAgain == MessageBoxResult.No)
                    break;
            }
        }

    }
}
