using BlockChainProcessor.Core.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainProcessor.TransactionExcecutors
{
    public interface ITransactionExcecutor
    {
        bool Excecute(TransactionRequest transactionRequest);
    }
}
