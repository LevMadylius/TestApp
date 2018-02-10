using Xamarin.Forms;

namespace TestApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            //BindingContext = new TestApp.ViewModel.MainViewModel();
            
		}

        public MainPage(string url)
        {
            InitializeComponent();
            BindingContext = new TestApp.ViewModel.MainViewModel(url);
            var navigationCount = Navigation.NavigationStack.Count;
        }
	}
}
