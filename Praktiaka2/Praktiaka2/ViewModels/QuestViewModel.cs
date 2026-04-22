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
        private List<Question> _questionsList;
        private string _activeQuestionText = "Завантаження...";

        public QuestViewModel()
        {
            _questionsList = _dataService.GetQuestions();
            if (_questionsList != null && _questionsList.Count > 0)
            {
                // Присвоюємо значення через властивість, щоб спрацював Notify
                ActiveQuestionText = _questionsList[0].Text;
            }
        }

        public string ActiveQuestionText
        {
            get => _activeQuestionText;
            set
            {
                _activeQuestionText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}