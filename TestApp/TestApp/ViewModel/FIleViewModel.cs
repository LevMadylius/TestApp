using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestApp.ViewModel
{
    public class FIleViewModel : BaseViewModel
    {
        
        private string _requestURL;
        public string RequestURL
        {
            get
            {
                return _requestURL;
            }
            set
            {
                if(_requestURL != value)
                {
                    _requestURL = value;
                    OnPropertyChanged("RequestURL");
                }
            }
        }

        public FIleViewModel()
        {

        }

        public FIleViewModel(string url)
        {
            RequestURL = url;
        }
    }
}
