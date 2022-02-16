using System.Collections.Generic;

namespace BlockChainProcessor.Core.Models
{
    public sealed class Wallet
    {
        public string Address { get; set; }
        public List<Block> Blocks { get; set; }
    }
}