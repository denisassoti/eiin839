using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer
{
    internal class MyMethods
    {
        public string Method1(string param1)
        {
            return "<html><body> Hello " + param1 +"</body></html>";
        }
        public string Method2(string param1, string param2)
        {
            return "<html><body> Hello " + param1 + " et " + param2 + "</body></html>";
        }

    }
}
