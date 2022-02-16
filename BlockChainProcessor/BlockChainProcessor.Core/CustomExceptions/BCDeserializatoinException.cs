using System;

namespace BlockChainProcessor.Core.CustomExceptions
{
    public class BCDeserializatoinException : Exception
    {
        public BCDeserializatoinException(string message) : base(message)
        {
        }
    }
}