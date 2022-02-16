using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Loggers;
using System.Linq;

namespace BlockChainProcessor.Commands
{
    public sealed class NftOwnershipCommandProcessor : ICommandProcessor
    {
        private readonly BlockChain blockChain = BlockChain.Instance();
        private readonly ILogger logger = new LoggerFactory().CreateLogger();

        public void Excecute(string parameterString)
        {
            // here parameterString refer to the token id

            Wallet wallet = blockChain.Wallets.FirstOrDefault(w => w.Blocks.Any(b => b.TokenId.Equals(parameterString)));

            if (wallet != null)
            {
                logger.Write(string.Format(Constants.Message.NftOwned, parameterString, wallet.Address));
                return;
            }

            logger.Write(string.Format(Constants.Message.NftNotOwned, parameterString));
        }
    }
}