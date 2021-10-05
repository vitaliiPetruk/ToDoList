using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    class Model : INotifyPropertyChanged
    {
        public DateTime CreationData { get; set; } = DateTime.Now;

        private bool _isDone;
        private string _text;
        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value) // Check for changes DataGridCheckBoxColumn Done
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value) // Check for changes DataGridTextColumn Need to do
                    return;
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "") // Subscription to a change event
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
