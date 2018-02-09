using System;
using System.Collections.Generic;
using System.Text;

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
