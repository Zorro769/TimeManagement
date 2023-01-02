using System;
using System.ComponentModel;
using Microsoft.Toolkit.Uwp.Notifications;


namespace Time.Model
{
    class TodoModel: INotifyPropertyChanged
    {
        public  DateTime _createDate;

        private string _text;
        private bool _isDone;
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

		

		public event PropertyChangedEventHandler PropertyChanged;
		public void CheckTimeAndSendNotify()
		{
			while (true)
			{
				if(_finishDate == DateTime.Now)
				{
                    new ToastContentBuilder()
					.AddArgument("action", "viewConversation")
					.AddArgument("conversationId", 9813)
					.AddText("Andrew sent you a picture")
					.AddText("Check this out, The Enchantments in Washington!")
					.Show();
                }
			}

		}

		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
