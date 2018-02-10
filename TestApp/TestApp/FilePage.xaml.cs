using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilePage : ContentPage
	{
		public FilePage ()
		{
			InitializeComponent ();
            BindingContext = new TestApp.ViewModel.FIleViewModel();
        }

        public FilePage(string url)
        {
            InitializeComponent();
            BindingContext =  new TestApp.ViewModel.FIleViewModel(url);
        }
    }
}