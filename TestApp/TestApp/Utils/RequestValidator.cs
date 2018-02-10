using System;

namespace TestApp.Utils
{
    public static class RequestValidator
    {
        public static bool CheckURI(string requestStringURL)
        {
            return (Uri.IsWellFormedUriString(requestStringURL, UriKind.Absolute)) ? true : false;
            
        }
    }
}
