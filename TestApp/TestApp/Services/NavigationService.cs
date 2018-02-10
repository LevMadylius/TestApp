using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace TestApp.Services
{
    public class NavigationService : INavigationService
    {
        public async void NavigateBack()
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PopModalAsync();
        }

        public async void NavigateToContent(string url)
        {
            var currentPage = GetCurrentPage();
            // implement constructor with params
            await currentPage.Navigation.PushModalAsync(new MainPage(url));
        }

        public async void NavigateToInfo<T>(T info)
        {
            var currentPage = GetCurrentPage();
            // implement constructor with params
            await currentPage.Navigation.PushModalAsync(new InfoPage(info));
        }

        private Page GetCurrentPage()
        {
            Page currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            return currentPage;
        }
    }
}
