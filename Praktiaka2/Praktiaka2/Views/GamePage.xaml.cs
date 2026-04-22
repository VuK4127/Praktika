using System.Windows;
using System.Windows.Controls;

namespace Praktiaka2.Views
{
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            // Отримуємо відповідь, прибираємо зайві пробіли
            string userAnswer = AnswerInput.Text.Trim().ToLower();

            // Тимчасова перевірка для 4 етапу
            if (userAnswer == "прекрасний")
            {
                MessageBox.Show("Правильно! Відповідь вірна.", "Успіх");
                NextBtn.IsEnabled = true;  // Активуємо кнопку "Наступне"
                CheckBtn.IsEnabled = false; // Деактивуємо кнопку перевірки
            }
            else
            {
                MessageBox.Show("Неправильно. Спробуйте ще раз!", "Помилка");
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            // Логіка переходу до наступного питання (для Етапу 5)
            AnswerInput.Clear();
            CheckBtn.IsEnabled = true;
            NextBtn.IsEnabled = false;

            MessageBox.Show("Наступне питання завантажується... ", "Інфо");
        }
    }
}