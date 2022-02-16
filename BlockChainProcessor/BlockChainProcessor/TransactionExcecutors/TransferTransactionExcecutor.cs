using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockChainProcessor.TransactionExcecutors
{
    public sealed class TransferTransactionExcecutor : ITransactionExcecutor
    {
        private readonly BlockChain blockChain = BlockChain.Instance();

        public bool Excecute(TransactionRequest transactionRequest)
        {
            try
            {
                Block block = blockChain.Blocks.FirstOrDefault(b => b.TokenId.Equals(transactionRequest.TokenId));

                if (block == null)
                {
                    return false;
                }

                Wallet existingWallet = blockChain.Wallets.FirstOrDefault(w => w.Address.Equals(transactionRequest.From));

                if (existingWallet == null)
                {
                    return false;
                }

                existingWallet.Blocks.Remove(block);

                Wallet newWallet = blockChain.Wallets.FirstOrDefault(w => w.Address.Equals(transactionRequest.To));

                if (newWallet == null)
                {
                    newWallet = new Wallet
                    {
                        Address = transactionRequest.To,
                        Blocks = new List<Block>()
                    };

                    blockChain.Wallets.Add(newWallet);
                }

                newWallet.Blocks.Add(block);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}