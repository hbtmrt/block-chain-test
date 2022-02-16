using BlockChainProcessor.Loggers;

namespace BlockChainProcessor.Factories
{
    /// <summary>
    /// Resolves the type of the logger.
    /// </summary>
    public sealed class LoggerFactory
    {
        public ILogger CreateLogger()
        {
            // In fture we can add more loggers apart from ConsoleLogger.
            return new ConsoleLogger();
        }
    }
}