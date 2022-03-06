using BlockChainProcessor.Core.Models;
using BlockChainProcessor.Core.Statics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace BlockChainProcessor
{
    /// <summary>
    /// This contains the data.
    /// </summary>
    public sealed class BlockChain
    {
        #region Declarations

        private readonly ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        private static BlockChain instance = new BlockChain();
        private bool dataLoaded = false;

        #endregion Declarations

        #region Properties

        public static BlockChain Instance() => instance;

        public List<Wallet> Wallets { get; set; }
        public List<Block> Blocks { get; set; }

        #endregion Properties

        #region Constructor

        private BlockChain()
        {
            Blocks = new List<Block>();
            Wallets = new List<Wallet>();
        }

        #endregion Constructor

        #region Methods

        public void Reset()
        {
            instance = new BlockChain();
        }

        public void LoadData()
        {
            if (dataLoaded)
            {
                // Loading data can be performed only once.
                return;
            }

            cacheLock.EnterReadLock();

            try
            {
                if (File.Exists(Constants.DataStoreFilePath))
                {
                    string jsonString = File.ReadAllText(Constants.DataStoreFilePath);
                    BlockChain bc = JsonSerializer.Deserialize<BlockChain>(jsonString);

                    Blocks = bc.Blocks;
                    Wallets = bc.Wallets;

                    dataLoaded = true;
                }
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        public void PersistData()
        {
            cacheLock.EnterWriteLock();

            try
            {
                string jsonString = JsonSerializer.Serialize(this);
                Console.WriteLine(jsonString);
                File.WriteAllText(Constants.DataStoreFilePath, jsonString);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        #endregion Methods
    }
}