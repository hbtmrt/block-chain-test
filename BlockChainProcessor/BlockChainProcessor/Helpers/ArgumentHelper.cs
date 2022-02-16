namespace BlockChainProcessor.Helpers
{
    /// <summary>
    /// A helper to deal with command line arguments.
    /// </summary>
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