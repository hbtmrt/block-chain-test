using BlockChainProcessor.Core.CustomExceptions;
using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Loggers;
using System.Collections.Generic;
using System.Linq;

namespace BlockChainProcessor.Commands
{
    public sealed class WalletOwnershipCommandProcessor : ICommandProcessor
    {
        private readonly BlockChain blockChain = BlockChain.Instance();
        private readonly ILogger logger = new LoggerFactory().CreateLogger();

        public void Excecute(string parameterString)
        {
            // here parameterString referes to the address of the wallet
            Wallet wallet = blockChain.Wallets.FirstOrDefault(w => w.Address.Equals(parameterString));

            if (wallet == null)
            {
                logger.Write(string.Format(Constants.Message.WalletWithoutToken, parameterString));
                return;
            }

            List<string> tokens = wallet.Blocks.Select(b => b.TokenId).ToList();

            if (tokens.Count == 0)
            {
                logger.Write(string.Format(Constants.Message.WalletWithoutToken, parameterString));
                return;
            }

            logger.Write(string.Format(Constants.Message.WalletHasTokens, parameterString, tokens.Count));

            tokens.ForEach(token =>
            {
                logger.Write(token);
            });
        }
    }
}