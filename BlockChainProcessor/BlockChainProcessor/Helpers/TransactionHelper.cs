using BlockChainProcessor.Core.Requests;
using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Loggers;
using BlockChainProcessor.TransactionExcecutors;
using System.Collections.Generic;

namespace BlockChainProcessor.Helpers
{
    public sealed class TransactionHelper
    {
        private readonly ILogger logger = new LoggerFactory().CreateLogger();

        internal void Excecute(List<TransactionRequest> transactions)
        {
            int transactionCount = 0;
            transactions.ForEach(transaction =>
            {
                ITransactionExcecutor excecutor = new TransactionExcecutorFactory().CreateInstance(transaction.Type);

                if (excecutor.Excecute(transaction))
                {
                    transactionCount++;
                }
            });

            logger.Write(string.Format(Constants.Message.MintSuccessfulFormat, transactionCount));
        }
    }
}