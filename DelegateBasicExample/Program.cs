using System;
using System.IO;
namespace DelegateBasicExample
{
    class Program
    {
        //delegate could be accessed everywhere within the program class

        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();
            
            LogDel LogTextToScreen = new LogDel(log.LogTextToScreen);
            LogDel LogTextToFile = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogTextToScreen + LogTextToFile;

            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            multiLogDel(name);
            Console.ReadKey();
        }
        
    }
    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        //wrties the user input to a text file
        public void LogTextToFile(string text)
        {
            //logic code
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}