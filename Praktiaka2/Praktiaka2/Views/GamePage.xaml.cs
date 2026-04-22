using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Praktiaka2.ViewModels;

namespace Praktiaka2.Views
{
    public partial class GamePage : Page
    {
        private QuestViewModel _viewModel;

        public GamePage()
        {
            InitializeComponent();
            
            _viewModel = (QuestViewModel)this.DataContext;
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CurrentQuestion == null) return;

            
            string userAnswer = AnswerInput.Text.Trim().ToLower();
            string correctAnswer = _viewModel.CurrentQuestion.CorrectAnswer.ToLower();

            if (userAnswer == correctAnswer)
            {
                MessageBox.Show("Правильно! Нараховано +10 балів.", "Успіх");
                _viewModel.CurrentUser.Score += 10;

                NextBtn.IsEnabled = true;
                CheckBtn.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Неправильно. Спробуйте ще раз!", "Помилка");
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.NextQuestion())
            {
                
                AnswerInput.Clear();
                CheckBtn.IsEnabled = true;
                NextBtn.IsEnabled = false;
            }
            else
            {
                
                string finalName = _viewModel.CurrentUser.Name;
                int finalScore = _viewModel.CurrentUser.Score;

                NavigationService.Navigate(new FinishPage(finalName, finalScore));
            }
        }
    }
}