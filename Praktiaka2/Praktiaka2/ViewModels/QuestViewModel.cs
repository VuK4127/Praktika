using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Praktiaka2.Models;
using Praktiaka2.Services;

namespace Praktiaka2.ViewModels
{
    public class QuestViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService = new DataService();
        private ObservableCollection<Question> _questions = null!;
        private User _currentUser = null!;
        private string _activeQuestionText = string.Empty;
        private int _currentQuestionIndex = 0;

        public QuestViewModel()
        {
            CurrentUser = new User { Name = "Гравець", Score = 0 };
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            try
            {
                var data = _dataService.GetQuestions();
                Questions = new ObservableCollection<Question>(data);
                UpdateQuestion();
            }
            catch
            {
                Questions = new ObservableCollection<Question>();
                ActiveQuestionText = "Помилка: файл Data/questions.json не знайдено!";
            }
        }

        public User CurrentUser { get => _currentUser; set { _currentUser = value; OnPropertyChanged(); } }
        public ObservableCollection<Question> Questions { get => _questions; set { _questions = value; OnPropertyChanged(); } }
        public string ActiveQuestionText { get => _activeQuestionText; set { _activeQuestionText = value; OnPropertyChanged(); } }

        public Question? CurrentQuestion => (Questions != null && _currentQuestionIndex < Questions.Count)
            ? Questions[_currentQuestionIndex] : null;

        public void UpdateQuestion()
        {
            if (CurrentQuestion != null) ActiveQuestionText = CurrentQuestion.Text;
        }

        public bool NextQuestion()
        {
            if (_currentQuestionIndex < Questions.Count - 1)
            {
                _currentQuestionIndex++;
                UpdateQuestion();
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}