using TestApp.Model;

namespace TestApp.ViewModel
{
    public class ItemViewModel : BaseViewModel
    {
        private InfoContainer _data;
        public InfoContainer Data
        {
            get
            {
                return _data;
            }
            set
            {
                if(_data != value)
                {
                    _data = value;
                    OnPropertyChanged("Data");
                }
            }
        }
        private bool _isSelected= false;
        public bool IsSeLected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;

                    OnPropertyChanged("IsSeLected");
                }
            }
        }
    }
}