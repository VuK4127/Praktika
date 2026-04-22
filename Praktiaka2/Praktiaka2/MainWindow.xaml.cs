using System.Windows;
using System.Windows.Media;

namespace Praktiaka2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameInput.Text))
            {
                StatusMessage.Text = "Введіть ім'я перед початком!";
                StatusMessage.Foreground = Brushes.Red;
            }
            else
            {
                QuestionDisplay.Text = "Як правильно пишеться слово: (пр..красний)?";
                StatusMessage.Text = $"Удачі, {UserNameInput.Text}!";
                StatusMessage.Foreground = Brushes.Blue;
            }
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserAnswerInput.Text.ToLower().Trim() == "прекрасний")
            {
                StatusMessage.Text = "Правильно! Ви молодець!";
                StatusMessage.Foreground = Brushes.Green;
            }
            else
            {
                StatusMessage.Text = "Помилка. Спробуйте ще раз.";
                StatusMessage.Foreground = Brushes.Red;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            StatusMessage.Text = "Перехід до наступного питання...";
            StatusMessage.Foreground = Brushes.Black;
        }
    }
}