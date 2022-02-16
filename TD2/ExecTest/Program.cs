using System;

namespace ExeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {

                Console.WriteLine("<html><body> Hello " + args[0] +" "+args[1]+ "</body></html>");
            }
            else
                Console.WriteLine("No parameter");
        }
    }
}
