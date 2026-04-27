using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            CheckAnswer();
        }

        private void AnswerInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (NextBtn.IsEnabled)
                    MoveNext();
                else
                    CheckAnswer();
            }
        }

        private void CheckAnswer()
        {
            if (_viewModel.CurrentQuestion == null) return;

            if (AnswerInput.Text.Trim().ToLower() == _viewModel.CurrentQuestion.CorrectAnswer.ToLower())
            {
                StatusText.Text = "✔ Правильно!";
                StatusText.Foreground = System.Windows.Media.Brushes.Green;
                _viewModel.CurrentUser.Score += 10;
                NextBtn.IsEnabled = true;
                CheckBtn.IsEnabled = false;
            }
            else
            {
                StatusText.Text = "✘ Спробуйте ще раз!";
                StatusText.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            MoveNext();
        }

        private void MoveNext()
        {
            if (_viewModel.NextQuestion())
            {
                AnswerInput.Clear();
                AnswerInput.Focus();
                StatusText.Text = "";
                CheckBtn.IsEnabled = true;
                NextBtn.IsEnabled = false;
            }
            else
            {
                NavigationService.Navigate(new FinishPage(_viewModel.CurrentUser.Name, _viewModel.CurrentUser.Score));
            }
        }
    }
}