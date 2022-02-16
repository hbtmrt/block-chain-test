using BlockChainProcessor.Helpers;

namespace BlockChainProcessor.Commands
{
    /// <summary>
    /// Handles --read-inline operations.
    /// </summary>
    public sealed class ReadLineCommandProcessor : ICommandProcessor
    {
        public void Excecute(string parameterString)
        {
            new TransactionHelper().Excecute(parameterString);
        }
    }
}