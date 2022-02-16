using BlockChainProcessor.Core.Statics;

namespace BlockChainProcessor.Core.Requests
{
    public sealed class TransactionRequest
    {
        public TransactionType Type { get; set; }
        public string TokenId { get; set; }
        public string Address { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}