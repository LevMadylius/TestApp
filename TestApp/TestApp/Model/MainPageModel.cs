using System.ComponentModel;
using TestApp.Resource;

namespace TestApp.Model
{
    public class MainPageModel: INotifyPropertyChanged
    {
        #region MainPageProperties
        private bool _isFileContentVisible = false;
        public bool IsFileContentVisible
        {
            get
            {
                return _isFileContentVisible;
            }
            set
            {
                if (value != _isFileContentVisible)
                {
                    _isFileContentVisible = value;
                    OnPropertyChanged("IsFileContentVisible");
                }
            }
        }

        private bool _isFolderContentVisible = false;
        public bool IsFolderContentVisible
        {
            get
            {
                return _isFolderContentVisible;
            }
            set
            {
                if (value != _isFolderContentVisible)
                {
                    _isFolderContentVisible = value;
                    OnPropertyChanged("IsFolderContentVisible");
                }
            }
        }

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

        //private static readonly MainPageModel _source = new MainPageModel();

        public event PropertyChangedEventHandler PropertyChanged;

        //public static MainPageModel Source
        //{
        //    get
        //    {
        //        return _source;
        //    }
        //}

        //private MainPageModel()
        //{

        //}

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
