using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Services
{
    public interface INavigationService
    {
        void NavigateToContent(string url);
        void NavigateToInfo<T>(T info);
        void NavigateBack();
    }
}
