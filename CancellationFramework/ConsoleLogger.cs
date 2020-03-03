using System;

namespace Common
{
    public class ConsoleLogger
    {
        public void Log(string message) => Console.WriteLine($"{DateTime.Now} : {message}");
    }
}
