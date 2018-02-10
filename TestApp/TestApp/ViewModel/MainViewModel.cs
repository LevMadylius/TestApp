using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Services;
using Xamarin.Forms;
using TestApp.Utils;
using System.Text;

namespace TestApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private DataService service = new DataService();
        private MainPageModel _pageModel = new MainPageModel();
        public MainPageModel PageModel
        {
            get
            {
                return _pageModel;
            }
        }

        private KeyValuePair<string, ItemViewModel> _selectedItem;
        public KeyValuePair<string, ItemViewModel> SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {

                if (value.Key != _selectedItem.Key)
                {
                    if (_selectedItem.Value != null) _selectedItem.Value.IsSeLected = false;
                    value.Value.IsSeLected = true;
                    _selectedItem = value;
                    PageModel.TapCount = 0;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public Dictionary<string,ItemViewModel>_dictionary;
        public Dictionary<string,ItemViewModel> ContentDictionary
        {
            get
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

        #region Constructors
        public MainViewModel()
        {
            InfoCommand = new Command(OpenInfo);
            GetCommand = new Command(GetRequest);
            TapCommand = new Command<KeyValuePair<string, ItemViewModel>>(OpenResource);

        }

        public MainViewModel(string url)
        {
            InfoCommand = new Command(OpenInfo);
            GetCommand = new Command(GetRequest);
            TapCommand = new Command<KeyValuePair<string, ItemViewModel>>(OpenResource);
            PageModel.RequestStringURL = url;
            GetCommand.Execute(null);
        }

        #endregion

        #region Commands and their handlers
        public ICommand GetCommand { get; set; }

        public ICommand InfoCommand { get; set; }

        public ICommand TapCommand { get; set; }

        private void OpenResource(KeyValuePair<string, ItemViewModel> container)
        {
            if (++PageModel.TapCount % 2 == 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(PageModel.RequestStringURL);
                string newURL;

                NavigationService navigationService = new NavigationService();
                if (container.Value.Data.Isdir)
                {
                    builder.Append(container.Key);
                    newURL = builder.ToString();
                    navigationService.NavigateToFolder(newURL);
                    
                }
                else
                {
                    builder.Append("/");
                    builder.Append(container.Key);
                    newURL = builder.ToString();
                    navigationService.NavigateToFile(newURL);
                }
                PageModel.TapCount = 0;
            }

        }      

        private async void GetRequest()
        {
            PageModel.StatusStringUpdate(true, "Pinging Resource...");
            bool resourceReachable = await PingResource();
            if (!RequestValidator.CheckURI(PageModel.RequestStringURL))
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
                var result = await service.GetContentInfoAsync<InfoContainer>(PageModel.RequestStringURL) ?? null;
                ContentDictionary = ConvertResponceToDictionary(result);
                PageModel.StatusStringUpdate(false, "");
            }
            catch(Exception ex)
            {
                PageModel.StatusStringUpdate(true, ex.Message);
            }
        }

        private Dictionary<string, ItemViewModel> ConvertResponceToDictionary(IDictionary<string, InfoContainer> container)
        {
            Dictionary<string, ItemViewModel> result = new Dictionary<string, ItemViewModel>();
            foreach(var el in container)
            {
                result.Add(el.Key, new ItemViewModel { Data = el.Value, IsSeLected = false });
            }
            return result;
        }

        private void OpenInfo()
        {
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateToInfo(SelectedItem.Value.Data);
        }
        #endregion


        private async Task<bool> PingResource()
        {
            bool result = await service.PingResource(PageModel.RequestStringURL);
            return result;
        }
    }
}
