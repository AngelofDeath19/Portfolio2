using System;
using System.ComponentModel;

namespace ZxcCursed.Models
{
    internal class ToDoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _isDone;
        public bool isDone
        {
            get 
            {
                return _isDone; 
            }
            set 
            {
                if (_isDone == value)
                {
                    return;
                }
                _isDone = value;
                OnPropertyChanged("isDone");
            }    
        }
        private string? _text;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string? text
        {
            get { return _text; }
            set 
            {
                if (_text == value)
                {
                    return;
                }
                _text = value; 
                OnPropertyChanged("text");
            }
        }
        protected virtual void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
