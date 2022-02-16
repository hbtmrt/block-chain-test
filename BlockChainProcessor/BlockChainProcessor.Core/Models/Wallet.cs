using System.Collections.Generic;

namespace BlockChainProcessor.Core.Models
{
    /// <summary>
    /// The model class of Wallet.
    /// </summary>
    public sealed class Wallet
    {
        public string Address { get; set; }
        public List<Block> Blocks { get; set; }
    }
}