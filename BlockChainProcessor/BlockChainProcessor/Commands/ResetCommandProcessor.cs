using BlockChainProcessor.Core.Statics;
using BlockChainProcessor.Factories;
using BlockChainProcessor.Loggers;

namespace BlockChainProcessor.Commands
{
    public sealed class ResetCommandProcessor : ICommandProcessor
    {
        private readonly BlockChain blockChain = BlockChain.Instance();
        private readonly ILogger logger = new LoggerFactory().CreateLogger();

        public void Excecute(string parameterString)
        {
            blockChain.Reset();
            logger.Write(Constants.Message.Reset);
        }
    }
}