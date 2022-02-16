using System;

namespace BlockChainProcessor.Loggers
{
    public sealed class ConsoleLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}