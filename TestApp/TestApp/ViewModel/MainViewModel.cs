using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Resource;
using TestApp.Services;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        DataService service = new DataService();
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isFileContentVisible = false;
        public bool IsFileContentVisible {
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

        private InfoContainer _containerInfo;
        public InfoContainer ContainerInfo
        {
            get
            {
                return _containerInfo;
            }
            set
            {
                if (_containerInfo != value && value != null)
                {
                    _containerInfo = value;
                    OnPropertyChanged("ContainerInfo");
                }
            }
        }

        private bool isValidRequest
        {
            get
            {

                return CheckURI();
            }
        }
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

                    if (!Uri.IsWellFormedUriString(_requestStringURL, UriKind.Absolute))
                    {
                        IsFileContentVisible = false;
                        IsFolderContentVisible = false;
                        StatusStringUpdate(true, "Uri is not correct");
                    }
                    else
                    {
                        StatusStringUpdate(false, null);
                    }
                }

            }

        }

        private string _contentUrlString;
        public string ContentUrlString
        {
            get
            {
                return _contentUrlString;
            }
            set
            {
                if (_contentUrlString != value)
                {
                    _contentUrlString = value;
                    OnPropertyChanged("ContentUrlString");
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


        public Dictionary<string, InfoContainer> _dictionary;
        public Dictionary<string, InfoContainer> FolderContentDictionary
        { get
            {            
                return _dictionary;
            }
            set
            {
                if(value != _dictionary && value != null)
                {
                    _dictionary = value;
                    OnPropertyChanged("FolderContentDictionary");
                }
            }
        }


        #endregion
        public ICommand GetCommand { get; set; }

        private ICommand _infoCommand;
        public ICommand InfoCommand {
            get
            {
                return _infoCommand;
            }
            set
            {
                if (value != _infoCommand)
                    _infoCommand = value;
            }
        }

        public MainViewModel()
        {
            InfoCommand = new Command(DoSomething);
            GetCommand = new Command(GetRequest);
            
        }

        private async Task<bool> PingResource()
        {
            bool result = await service.PingResource(_requestStringURL);
            return result;


        }

        private bool CheckURI()
        {
            if (Uri.IsWellFormedUriString(_requestStringURL, UriKind.Absolute))
            {
                StatusStringUpdate(false, null);
                return true;
            }
            else
            {
                IsFileContentVisible = false;
                IsFolderContentVisible = false;
                StatusStringUpdate(true, "Uri is not correct");
                return false;
            }
        }

        private async void GetRequest()
        {
            bool resourceReachable = await PingResource();
            if (!isValidRequest )
            {
                return;
            }
            if(!resourceReachable)
            {
                StatusStringUpdate(true, "Cannot reach a resource");
                return;
            }
            var extension = Path.GetExtension(RequestStringURL);          
            // indicates whether url has file extension
            if(string.IsNullOrEmpty(extension))
            {
                try
                {
                    IsFileContentVisible = false;
                    IsFolderContentVisible = true;

                    StatusStringUpdate(true, "Recieving information about folder");
                    ContainerInfo = await service.GetInfoAsync<InfoContainer>(RequestStringURL) ?? null;
                    StatusStringUpdate(true, "Recieving information about content of the folder");
                    FolderContentDictionary = await service.GetContentInfoAsync<InfoContainer>(RequestStringURL) ?? null;
                    StatusStringUpdate(false, "");


                }
                catch (Exception ex)
                {
                    StatusStringUpdate(true, ex.Message);
                }
            }
            else
            {
                IsFileContentVisible = true;
                IsFolderContentVisible = false;

                ContentUrlString = RequestStringURL;

            }


        }

        private  void DoSomething()
        {
            bool resourceReachable = true;
        }

        private void StatusStringUpdate(bool visible,string text)
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
