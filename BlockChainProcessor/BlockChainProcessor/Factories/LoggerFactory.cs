using BlockChainProcessor.Loggers;

namespace BlockChainProcessor.Factories
{
    public sealed class LoggerFactory
    {
        public ILogger CreateLogger()
        {
            // In fture we can add more loggers apart from ConsoleLogger.
            return new ConsoleLogger();
        }
    }
}