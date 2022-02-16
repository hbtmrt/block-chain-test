namespace BlockChainProcessor.Commands
{
    /// <summary>
    /// Contains methods related to command processors.
    /// </summary>
    public interface ICommandProcessor
    {
        void Excecute(string parameterString);
    }
}