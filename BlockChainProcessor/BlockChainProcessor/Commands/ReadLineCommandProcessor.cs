using BlockChainProcessor.Core.CustomExceptions;
using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Requests;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Helpers;
using BlockChainProcessor.TransactionExcecutors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainProcessor.Commands
{
    public sealed class ReadLineCommandProcessor : ICommandProcessor
    {
        public void Excecute(string parameterString)
        {
            TransactionRequest transaction = new JsonReaderHelper().Deserialize<TransactionRequest>(parameterString);
            ITransactionExcecutor excecutor = new TransactionExcecutorFactory().CreateInstance(transaction.Type);
            excecutor.Excecute(transaction);
        }
    }
}
