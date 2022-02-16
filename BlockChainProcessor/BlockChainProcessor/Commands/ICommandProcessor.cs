namespace BlockChainProcessor.Commands
{
    public interface ICommandProcessor
    {
        void Excecute(string parameterString);
    }
}