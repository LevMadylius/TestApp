using Xamarin.Forms;
using System.Linq;
using TestApp.Model;

namespace TestApp.Services
{
    public class NavigationService : INavigationService
    {
        public async void NavigateBack()
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PopModalAsync();
        }

        public async void NavigateToFile(string url)
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PushModalAsync(new FilePage(url));
        }

        public async void NavigateToFolder(string url)
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PushModalAsync(new MainPage(url));
        }

        public async void NavigateToInfo(InfoContainer info)
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PushModalAsync(new InfoPage(info));
        }

        private Page GetCurrentPage()
        {
            Page currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            return currentPage;
        }
    }
}
