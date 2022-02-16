namespace BlockChainProcessor.Core.Statics
{
    /// <summary>
    /// Store the constant values across the project.
    /// </summary>
    public static class Constants
    {
        public static class Command
        {
            public const string ReadLine = "read-inline";
            public const string ReadFile = "read-file";
            public const string NftOwnership = "nft";
            public const string WalletOwnership = "wallet";
            public const string Reset = "reset";
        }

        public static class Message
        {
            public const string MintSuccessfulFormat = "Read {0} transaction(s)";
            public const string NoArgumentProvided = "Error. No arguments have been provided.";
            public const string CommandShouldStartWithProgram = "Error. All commands should start with \"program\".";
            public const string CommonError = "Critical error. Please contact the administrator.";
            public const string ParameterFormatError = "Error. There is something wrong with the parameter string. Please check and try again.";
            public const string NotAValidFilePath = "Error. The file path provided is not valid.";
            public const string FileNotExist = "Error. The file does not exist.";
            public const string NftOwned = "Token {0} is owned by {1}.";
            public const string NftNotOwned = "Token {0} is not owned by any wallet.";
            public const string WalletHasTokens = "Wallet {0} holds {1} Tokens:";
            public const string WalletWithoutToken = "Wallet {0} holds no Tokens:";
            public const string Reset = "Program was reset.";
        }
    }
}