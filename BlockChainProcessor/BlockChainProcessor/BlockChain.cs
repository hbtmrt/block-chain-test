using BlockChainProcessor.Core.Models;
using System.Collections.Generic;

namespace BlockChainProcessor
{
    public sealed class BlockChain
    {
        private static BlockChain instance = new BlockChain();

        public static BlockChain Instance() => instance;

        public List<Wallet> Wallets { get; set; }
        public List<Block> Blocks { get; set; }

        private BlockChain()
        {
            Blocks = new List<Block>();
            Wallets = new List<Wallet>();
        }

        public void Reset()
        {
            instance = new BlockChain();
        }
    }
}