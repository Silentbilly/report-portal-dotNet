using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace report_portal_dotNet.UI.Utils
{
    public static class Guard
    {
        [DebuggerStepThrough]
        public static void IsNotNull<TExpection>(object argumentValue, string format, params object[] parameters) where TExpection : Exception
        {
            if (argumentValue == null)
            {
                throw GetException<TExpection>(format, parameters);
            }
        }

        private static TExpection GetException<TExpection>(string format, params object[] parameters)
        {
            string message = string.Format(CultureInfo.InvariantCulture, format, parameters);
            return (TExpection)Activator.CreateInstance(typeof(TExpection), message);
        }

        private static InvalidOperationException GetException(string format, params object[] parameters)
        {
            return new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, format, parameters));
        }
    }
}
