using System.Windows;
using System.Windows.Controls;
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

            if (AnswerInput.Text.Trim().ToLower() == _viewModel.CurrentQuestion.CorrectAnswer.ToLower())
            {
                MessageBox.Show("Правильно!");
                _viewModel.CurrentUser.Score += 10;
                NextBtn.IsEnabled = true;
                CheckBtn.IsEnabled = false;
            }
            else MessageBox.Show("Спробуйте ще раз!");
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
                // Передаємо ім'я та бали на фінальну сторінку
                NavigationService.Navigate(new FinishPage(_viewModel.CurrentUser.Name, _viewModel.CurrentUser.Score));
            }
        }
    }
}