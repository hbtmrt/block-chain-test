using BlockChainProcessor.Core.Requests;
using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Loggers;
using BlockChainProcessor.TransactionExcecutors;
using System;
using System.Collections.Generic;

namespace BlockChainProcessor.Helpers
{
    /// <summary>
    /// A helper to deal with transactions.
    /// </summary>
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

        internal void Excecute(string parameterString)
        {
            List<TransactionRequest> transactions = new List<TransactionRequest>();

            try
            {
                var transaction = new JsonReaderHelper().Deserialize<TransactionRequest>(parameterString);
                transactions.Add(transaction);
            }
            catch (Exception)
            {
                // could be due to having arrays
                transactions = new JsonReaderHelper().Deserialize<List<TransactionRequest>>(parameterString);
            }

            Excecute(transactions);
        }
    }
}