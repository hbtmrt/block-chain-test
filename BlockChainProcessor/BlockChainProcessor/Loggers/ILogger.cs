namespace BlockChainProcessor.Loggers
{
    /// <summary>
    /// Defines the logger related methods.
    /// </summary>
    public interface ILogger
    {
        void Write(string message);
    }
}