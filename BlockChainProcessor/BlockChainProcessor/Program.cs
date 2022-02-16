using BlockChainProcessor.Commands;
using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Helpers;
using BlockChainProcessor.Loggers;
using System;

namespace BlockChainProcessor
{
    internal class Program
    {
        private static readonly ArgumentHelper argumentHelper = new ArgumentHelper();
        private static readonly ILogger logger = new LoggerFactory().CreateLogger();

        private static void Main(string[] args)
        {
            bool quite = false;
            string commandArgument;

            while (!quite)
            {
                commandArgument = Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(commandArgument))
                    {
                        logger.Write(Constants.Message.NoArgumentProvided);
                        continue;
                    }

                    if (!commandArgument.StartsWith("program"))
                    {
                        logger.Write(Constants.Message.CommandShouldStartWithProgram);
                        continue;
                    }

                    string commandString = argumentHelper.GetCommandString(commandArgument);
                    string parameterString = argumentHelper.GetParameterString(commandArgument);

                    ICommandProcessor commandProcessor = new CommandProcessorFactory().CreateInstance(commandString);
                    commandProcessor.Excecute(parameterString);
                }
                catch (Exception ex)
                {
                    // Show error and let the user to type again.
                    Console.WriteLine("Error....");
                }
            }
        }
    }
}