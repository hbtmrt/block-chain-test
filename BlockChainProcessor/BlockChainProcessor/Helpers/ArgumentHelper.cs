using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainProcessor.Helpers
{
    public sealed class ArgumentHelper
    {
        public string GetCommandString(string[] args)
        {
            int firstArgumentIndex = 0;
            return args[firstArgumentIndex].Replace("--", "");
        }

        public string GetParameterString(string[] args)
        {
            return string.Join("", args).Replace("--", "").Replace("\'", "").Replace(GetCommandString(args), "");
        }
    }
}
