namespace BlockChainProcessor.Helpers
{
    public sealed class ArgumentHelper
    {
        internal string GetCommandString(string commandArgument)
        {
            return commandArgument.Split("program --")[1].Split(" ")[0].Trim();
        }

        internal string GetParameterString(string commandArgument)
        {
            return commandArgument.Split($"program --{GetCommandString(commandArgument)}")[1].Replace("\'", "").Trim();
        }
    }
}