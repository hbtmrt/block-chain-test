using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.TransactionExcecutors;

namespace BlockChainProcessor.Factories
{
    /// <summary>
    /// Resolves the type of the Transaction Excecutor based on the transaction type.
    /// </summary>
    public sealed class TransactionExcecutorFactory
    {
        public ITransactionExcecutor CreateInstance(TransactionType type)
        {
            return type switch
            {
                TransactionType.Mint => new MintTransactionExcecutor(),
                TransactionType.Burn => new BurnTransactionExcecutor(),
                _ => new TransferTransactionExcecutor()
            };
        }
    }
}