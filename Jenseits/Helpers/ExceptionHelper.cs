using System;
using System.Collections.Generic;
using System.Linq;

namespace Jenseits.Helpers
{
    public static class ExceptionHelper
    {
        const string _userStr = "UserId";
        const string _userNameStr = "UserName";
        const string _classStr = "Class";
        const string _methodStr = "Method";
        const string _exceptionStr = "Exception";
        const string _buildNumberAndVersionStr = "App Version and Build Number";

        public static void LogException(object classObj, string methodName, Exception exception, List<KeyValuePair<string, string>> extendedProperties = null)
        {
            string className = classObj.GetType().ToString();
            System.Diagnostics.Debug.WriteLine("{0}: {1} {2}: {3} {4}: {5}", _classStr, className, _methodStr, methodName, _exceptionStr, exception.Message);
        }
    }
}
