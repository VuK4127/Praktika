using System.Collections.Generic;
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
        private ObservableCollection<Question> _questions;
        private User _currentUser;
        private string _activeQuestionText;

        public QuestViewModel()
        {
            // Ініціалізація користувача
            CurrentUser = new User { Name = "Гравець", Score = 0 };

            // Завантаження питань в ObservableCollection
            var data = _dataService.GetQuestions();
            Questions = new ObservableCollection<Question>(data);

            if (Questions.Count > 0)
            {
                ActiveQuestionText = Questions[0].Text;
            }
        }

        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set { _questions = value; OnPropertyChanged(); }
        }

        public string ActiveQuestionText
        {
            get => _activeQuestionText;
            set { _activeQuestionText = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}