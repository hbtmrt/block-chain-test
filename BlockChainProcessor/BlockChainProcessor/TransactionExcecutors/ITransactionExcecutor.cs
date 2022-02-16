using BlockChainProcessor.Core.Requests;

namespace BlockChainProcessor.TransactionExcecutors
{
    /// <summary>
    /// Defines methods related to transaction excecutors.
    /// </summary>
    public interface ITransactionExcecutor
    {
        bool Excecute(TransactionRequest transactionRequest);
    }
}