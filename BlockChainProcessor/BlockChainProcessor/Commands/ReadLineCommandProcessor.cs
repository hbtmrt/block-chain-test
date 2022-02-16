using BlockChainProcessor.Helpers;

namespace BlockChainProcessor.Commands
{
    public sealed class ReadLineCommandProcessor : ICommandProcessor
    {
        public void Excecute(string parameterString)
        {
            new TransactionHelper().Excecute(parameterString);
        }
    }
}