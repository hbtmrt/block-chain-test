using BlockChainProcessor.Core.CustomExceptions;
using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Requests;
using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Loggers;
using System.Linq;

namespace BlockChainProcessor.TransactionExcecutors
{
    public sealed class MintTransactionExcecutor : ITransactionExcecutor
    {
        private readonly BlockChain blockChain = BlockChain.Instance();
        private readonly ILogger logger = new LoggerFactory().CreateLogger();

        public void Excecute(TransactionRequest transaction)
        {
            Block block = CreateBlock(transaction.TokenId);
            AddToWallet(transaction.Address, block);
            logger.Write(string.Format(Constants.Message.MintSuccessfulFormat, 1));
        }

        private void AddToWallet(string address, Block block)
        {
            Wallet wallet = blockChain.Wallets.FirstOrDefault(w => w.Address.Equals(address));

            if (wallet == null)
            {
                wallet = new Wallet()
                {
                    Address = address,
                    Blocks = new System.Collections.Generic.List<Block>()
                };

                blockChain.Wallets.Add(wallet);
            }

            wallet.Blocks.Add(block);
        }

        private Block CreateBlock(string tokenId)
        {
            if (blockChain.Blocks.FirstOrDefault(b => b.TokenId.Equals(tokenId)) != null)
            {
                throw new BCBlockAlreadyExistingException();
            }

            Block block = new Block()
            {
                TokenId = tokenId
            };

            blockChain.Blocks.Add(block);

            return block;
        }
    }
}