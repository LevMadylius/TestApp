using System.ComponentModel;
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

        public InfoViewModel(InfoContainer container)
        {
            Container = container;
        }

        public InfoViewModel()
        {
            
        }
    }
}
