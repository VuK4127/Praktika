using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Praktiaka2.Models;
using Praktiaka2.Services;

namespace Praktiaka2.ViewModels
{
    public class QuestViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService = new DataService();
        private List<Question> _questions;
        private int _currentIndex = 0;
        private string _currentQuestionText;

        public QuestViewModel()
        {
            _questions = _dataService.GetQuestions();
            if (_questions.Count > 0)
            {
                CurrentQuestionText = _questions[_currentIndex].Text;
            }
        }

        public string CurrentQuestionText
        {
            get => _currentQuestionText;
            set { _currentQuestionText = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}