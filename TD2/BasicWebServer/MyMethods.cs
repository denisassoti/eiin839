using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace BasicWebServer
{
    internal class MyMethods
    {
        //question 1
        public string Method1(string param1, string param2)
        {
            return "<html><body> Hello " + param1+ " "+ param2 + "</body></html>";
        }

        //question 2 
        public string ExecTest(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"D:\COURS NICE\annee 4\S8\SOC\TD\eiin839\TD2\ExecTest\bin\Debug\ExecTest.exe";
            start.Arguments = param1+" "+param2; 
            
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                    //Console.ReadLine();
                }
            }
        }

        //question 2 Bonus python script call
        public string ExecPython(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            // here we execute the python interpreter exe instead of the exe generate by a c# program 
            start.FileName = @"C:\Users\denis\AppData\Local\Programs\Python\Python310\python.exe";

            // here we specify the python script to be executed and the parameters
            var script = @"D:\COURS NICE\annee 4\S8\SOC\TD\eiin839\TD2\BasicWebServer\script.py";
            start.Arguments = $"\"{script}\" \"{param1}\" \"{param2}\"";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

    }
}
