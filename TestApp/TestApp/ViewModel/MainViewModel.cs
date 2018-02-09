using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Services;
using Xamarin.Forms;
using TestApp.Utils;

namespace TestApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        private DataService service = new DataService();
        private MainPageModel _pageModel;
        public MainPageModel PageModel
        {
            get
            {
                return MainPageModel.Source;
            }
        } 

        public Dictionary<string, InfoContainer> _dictionary;
        public Dictionary<string, InfoContainer> ContentDictionary
        { get
            {            
                return _dictionary;
            }
            set
            {
                if(value != _dictionary && value != null)
                {
                    _dictionary = value;
                    OnPropertyChanged("ContentDictionary");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #region Commands and their handlers
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

        public ICommand TapCommand { get; set; }

        public MainViewModel()
        {
            InfoCommand = new Command(DoSomething);
            GetCommand = new Command(GetRequest);
            TapCommand = new Command<KeyValuePair<string, InfoContainer>>(OpenResource);
            
        }

        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;
            InfoCommand = new Command(DoSomething);
            GetCommand = new Command(GetRequest);
            TapCommand = new Command<KeyValuePair<string, InfoContainer>>(OpenResource);
        }

        private  void OpenResource(KeyValuePair<string,InfoContainer> container)
        {
            var something = container;

        }

        

        private async void GetRequest()
        {
            bool resourceReachable = await PingResource();
            if (! RequestValidator.CheckURI(PageModel.RequestStringURL))
            {
                return;
            }
            if (!resourceReachable)
            {
                PageModel.StatusStringUpdate(true, "Cannot reach a resource");
                return;
            }
            try
            {
                PageModel.StatusStringUpdate(true, "Recieving information about content of the folder");
                ContentDictionary = await service.GetContentInfoAsync<InfoContainer>(PageModel.RequestStringURL) ?? null;
                PageModel.StatusStringUpdate(false, "");
            }
            catch(Exception ex)
            {
                PageModel.StatusStringUpdate(true, ex.Message);
            }
            //var extension = Path.GetExtension(PageModel.RequestStringURL);          
            //// indicates whether url has file extension
            //if(string.IsNullOrEmpty(extension))
            //{
            //    try
            //    {
            //    }
            //    catch (Exception ex)
            //    {
            //        StatusStringUpdate(true, ex.Message);
            //    }
            //}
            //else
            //{
            //    IsFileContentVisible = true;
            //    IsFolderContentVisible = false;

            //    PageModel.ContentUrlString = RequestStringURL;

            //}


        }

        private  void DoSomething()
        {
            bool resourceReachable = true;
        }
        #endregion


        private async Task<bool> PingResource()
        {
            bool result = await service.PingResource(PageModel.RequestStringURL);
            return result;
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
