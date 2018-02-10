using TestApp.Model;

namespace TestApp.Services
{
    public interface INavigationService
    {
        void NavigateToFolder(string url);
        void NavigateToFile(string url);
        void NavigateToInfo(InfoContainer info);
        void NavigateBack();
    }
}
