using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.models
{
    public static class Logger
    {
        public static string LogFileName = "logs.txt";
        public static void Log(string message)
        {
            Console.WriteLine(message);

            using (StreamWriter sw = new StreamWriter(LogFileName))
            {
                sw.WriteLine(message);
            }
        }
    }
}
