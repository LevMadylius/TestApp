using System.ComponentModel;
using TestApp.Resource;

namespace TestApp.Model
{
    public class MainPageModel: INotifyPropertyChanged
    {
        #region MainPageProperties
        private bool _isStatusStringVisible = false;
        public bool IsStatusStringVisible
        {
            get
            {
                return _isStatusStringVisible;
            }
            set
            {
                if (value != _isStatusStringVisible)
                {
                    _isStatusStringVisible = value;
                    OnPropertyChanged("IsStatusStringVisible");
                }
            }
        }
        public int TapCount = 0;
        
        private string _requestStringURL = RequestString.URLstring;
        public string RequestStringURL
        {
            get
            {
                return _requestStringURL;
            }
            set
            {
                if (_requestStringURL != value)
                {
                    _requestStringURL = value;
                    OnPropertyChanged("RequestStringURL");
                }

            }

        }

        private string _statusString;
        public string StatusString
        {
            get
            {
                return _statusString;
            }
            set
            {
                if (_statusString != value)
                {
                    _statusString = value;
                    OnPropertyChanged("StatusString");
                }
            }
        }
        
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;


        public void StatusStringUpdate(bool visible, string text)
        {
            IsStatusStringVisible = true;
            StatusString = text;
        }


        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
