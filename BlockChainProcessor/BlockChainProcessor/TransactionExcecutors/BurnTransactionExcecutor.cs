using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Requests;
using System;
using System.Linq;

namespace BlockChainProcessor.TransactionExcecutors
{
    /// <summary>
    /// Implements Burn transaction related functions.
    /// </summary>
    public sealed class BurnTransactionExcecutor : ITransactionExcecutor
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

                blockChain.Wallets.Where(w => w.Blocks.Contains(block)).ToList().ForEach(w =>
                {
                    w.Blocks.Remove(block);
                });

                blockChain.Blocks.Remove(block);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}