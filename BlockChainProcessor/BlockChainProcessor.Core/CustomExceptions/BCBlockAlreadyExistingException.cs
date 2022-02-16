using System;

namespace BlockChainProcessor.Core.CustomExceptions
{
    /// <summary>
    /// Used when the block already exists in the data.
    /// </summary>
    public class BCBlockAlreadyExistingException : Exception
    {
    }
}