using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
	public partial class InfoPage : ContentPage
	{
		public InfoPage ()
		{
			InitializeComponent ();
		}

        public InfoPage(InfoContainer info, string name)
        {
            InitializeComponent();
            BindingContext = new TestApp.ViewModel.InfoViewModel(info, name);
        }
	}
}