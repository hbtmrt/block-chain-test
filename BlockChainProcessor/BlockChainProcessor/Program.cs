using BlockChainProcessor.Commands;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Helpers;
using System;

namespace BlockChainProcessor
{
    internal class Program
    {
        private static readonly ArgumentHelper argumentHelper = new ArgumentHelper();

        private static void Main(string[] args)
        {
            bool quite = false;
            string command;

            while (!quite)
            {
                command = Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(command))
                    {
                        // TODO: Show error message.
                        Console.WriteLine("No arguments has been provided.");
                        continue;
                    }

                    string commandString = argumentHelper.GetCommandString(args);
                    string parameterString = argumentHelper.GetParameterString(args);

                    ICommandProcessor commandProcessor = new CommandProcessorFactory().CreateInstance(commandString);
                    commandProcessor.Excecute(parameterString);
                }
                catch (Exception ex)
                {
                    // Show error and let the user to type again.
                }
            }
        }
    }
}