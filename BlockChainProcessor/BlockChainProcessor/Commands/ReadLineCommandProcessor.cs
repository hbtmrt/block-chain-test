using BlockChainProcessor.Core.Requests;
using BlockChainProcessor.Helpers;
using System;
using System.Collections.Generic;

namespace BlockChainProcessor.Commands
{
    public sealed class ReadLineCommandProcessor : ICommandProcessor
    {
        public void Excecute(string parameterString)
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

            new TransactionHelper().Excecute(transactions);
        }
    }
}