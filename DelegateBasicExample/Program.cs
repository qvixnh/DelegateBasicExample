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
            //LogDel logDel = new LogDel(LogTextToScreen);
            LogDel logDel = new LogDel(LogTextToFile);

            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            logDel(name);
            Console.ReadKey();
        }
        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        //wrties the user input to a text file
        static void LogTextToFile(string text)
        {
            //logic code
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"),true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}