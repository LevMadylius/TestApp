using TestApp.Model;

namespace TestApp.ViewModel
{
    public class InfoViewModel : BaseViewModel
    {
        private InfoContainer _container;
        public InfoContainer Container
        {
            get
            {
                return _container;
            }
            set
            {
                if(_container != value)
                {
                    _container = value;
                    OnPropertyChanged("Container");
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public InfoViewModel(InfoContainer container, string name)
        {
            Container = container;
            Name = name;
        }

        public InfoViewModel()
        {
            
        }
    }
}
