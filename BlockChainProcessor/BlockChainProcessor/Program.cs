using BlockChainProcessor.Commands;
using BlockChainProcessor.Core.CustomExceptions;
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
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            bool quite = false;
            string commandArgument;

            BlockChain.Instance().LoadData();

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
                catch (BCDeserializatoinException)
                {
                    logger.Write(Constants.Message.ParameterFormatError);
                }
                catch (BCNotAFilePathException)
                {
                    logger.Write(Constants.Message.NotAValidFilePath);
                }
                catch (BCFileNotExistException)
                {
                    logger.Write(Constants.Message.FileNotExist);
                }
                catch (Exception)
                {
                    logger.Write(Constants.Message.CommonError);
                }
            }
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            BlockChain.Instance().PersistData();
        }
    }
}