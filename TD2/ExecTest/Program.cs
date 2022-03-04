using System;

namespace ExeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {

                Console.WriteLine("<html><body> External c# .exe call : Param 1 =  " + args[0] +" Param 2 ="+args[1]+ "</body></html>");
            }
            else
                Console.WriteLine("No parameter");
        }
    }
}
