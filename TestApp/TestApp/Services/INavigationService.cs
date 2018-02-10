using TestApp.Model;

namespace TestApp.Services
{
    public interface INavigationService
    {
        void NavigateToContent(string url);
        void NavigateToInfo(InfoContainer info);
        void NavigateBack();
    }
}
