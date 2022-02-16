using BlockChainProcessor.Core.CustomExceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BlockChainProcessor.Helpers
{
    /// <summary>
    /// A helper to deal with Json related opeartions.
    /// </summary>
    public sealed class JsonReaderHelper
    {
        public T Deserialize<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                throw new BCDeserializatoinException(ex.Message);
            }
        }

        public List<T> Deserialize<T>(List<string> jsonStrings)
        {
            try
            {
                List<T> objects = new List<T>();

                jsonStrings.ForEach(s =>
                {
                    objects.Add(Deserialize<T>(s));
                });

                return objects;
            }
            catch (Exception ex)
            {
                throw new BCDeserializatoinException(ex.Message);
            }
        }
    }
}