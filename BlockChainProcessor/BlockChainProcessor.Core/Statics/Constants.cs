using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainProcessor.Core.Statics
{
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
        }
    }
}
