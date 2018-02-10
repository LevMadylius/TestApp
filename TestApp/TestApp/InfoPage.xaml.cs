using TestApp.Model;
using Xamarin.Forms;

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