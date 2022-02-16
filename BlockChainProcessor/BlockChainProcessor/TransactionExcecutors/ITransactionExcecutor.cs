using BlockChainProcessor.Core.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainProcessor.TransactionExcecutors
{
    public interface ITransactionExcecutor
    {
        void Excecute(TransactionRequest transaction);
    }
}
