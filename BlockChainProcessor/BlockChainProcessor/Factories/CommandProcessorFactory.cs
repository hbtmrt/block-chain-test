using BlockChainProcessor.Commands;
using BlockChainProcessor.Core.Statics;

namespace BlockChainProcessor.Factories
{
    public sealed class CommandProcessorFactory
    {
        public ICommandProcessor CreateInstance(string command)
        {
            if (command.Equals(Constants.Command.ReadLine))
            {
                return new ReadLineCommandProcessor();
            }

            if (command.Equals(Constants.Command.ReadFile))
            {
                return new ReadFileCommandProcessor();
            }

            if (command.Equals(Constants.Command.NftOwnership))
            {
                return new NftOwnershipCommandProcessor();
            }

            if (command.Equals(Constants.Command.WalletOwnership))
            {
                return new WalletOwnershipCommandProcessor();
            }

            return new ResetCommandProcessor();
        }
    }
}