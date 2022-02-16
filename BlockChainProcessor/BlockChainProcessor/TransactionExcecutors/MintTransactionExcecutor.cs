using BlockChainProcessor.Core.CustomExceptions;
using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Requests;
using System;
using System.Linq;

namespace BlockChainProcessor.TransactionExcecutors
{
    public sealed class MintTransactionExcecutor : ITransactionExcecutor
    {
        private readonly BlockChain blockChain = BlockChain.Instance();

        public bool Excecute(TransactionRequest transactionRequest)
        {
            try
            {
                Block block = CreateBlock(transactionRequest.TokenId);
                AddToWallet(transactionRequest.Address, block);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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