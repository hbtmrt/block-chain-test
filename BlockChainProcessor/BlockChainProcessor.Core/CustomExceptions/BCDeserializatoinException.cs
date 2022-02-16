using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainProcessor.Core.CustomExceptions
{
    public class BCDeserializatoinException : Exception
    {
        public BCDeserializatoinException(string message) : base(message)
        {
        }
    }
}
