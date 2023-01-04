using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Xaml;
using RoutedEventArgs = System.Windows.RoutedEventArgs;

namespace Time.Model
{
    class TodoModel: INotifyPropertyChanged
    {
        public  DateTime _createDate;

        private string _text;
        private bool _isDone;
		private bool _start;
        public DateTime _finishDate;


        public bool IsDone
		{
			get { return _isDone; }
			set 
			{
				if (_isDone == value)
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
				if (_text == value)
					return;
				_text = value;
				OnPropertyChanged("Text");
			}
		}
        public DateTime CreationDate
        {
            get { return _createDate; }
            set
            {
                if (_createDate == value)
                    return;
                _createDate = value;
                OnPropertyChanged("FinishDate");
            }
        }
        public DateTime FinishDate
		{
			get { return _finishDate; }
			set
			{
				if (_finishDate == value)
					return;
				_finishDate = value;
				OnPropertyChanged("FinishDate");
			}
		}

        public bool Start
        {
            get { return _start; }
            set
            {
                if (_start == value)
                    return;
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; 

        protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
