using BlockChainProcessor.Core.CustomExceptions;
using BlockChainProcessor.Helpers;
using System.IO;

namespace BlockChainProcessor.Commands
{
    /// <summary>
    /// Handles --read-file operations.
    /// </summary>
    public sealed class ReadFileCommandProcessor : ICommandProcessor
    {
        public void Excecute(string parameterString)
        {
            if (!File.Exists(parameterString))
            {
                throw new BCFileNotExistException();
            }

            using StreamReader reader = new StreamReader(parameterString);
            string content = reader.ReadToEnd();

            new TransactionHelper().Excecute(content);
        }
    }
}