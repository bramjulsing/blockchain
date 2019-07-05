using System;
using System.Collections.Generic;

namespace BlockchainProgram
{
    public class Blockchain
    {
        public int Difficulty { set; get; } = 2;
        public int Reward = 1; // 1 cryptocurrency
        public IList<Block> Chain { set;  get; }
        IList<Transaction> PendingTransactions = new List<Transaction>();

        public Blockchain()
        {
            InitializeChain();
            AddGenesisBlock();
        }


        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        public Block CreateGenesisBlock()
        {
            Block block = new Block(DateTime.Now, null, PendingTransactions);
            block.Mine(Difficulty);
            PendingTransactions = new List<Transaction>();
            return block;
        }

        public void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock());
        }
        
        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void SubmitTransaction(Transaction transaction)
        {
            PendingTransactions.Add(transaction);
        }

        // public void ExecuteTransactions()
        // {
        //     Console.WriteLine(JsonConvert.SerializeObject(PendingTransactions, Formatting.Indented));
        //     foreach (Transaction transaction in PendingTransactions)
        //     {
        //         transaction.Execute();
        //     }
        // }

        public void ProcessPendingTransactions(String miner)
        {
            Block block = new Block(DateTime.Now, GetLatestBlock().Hash, PendingTransactions);
            AddBlock(block);

            PendingTransactions = new List<Transaction>();
            SubmitTransaction(new Transaction(null, miner, Reward));
        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Mine(this.Difficulty);
            Chain.Add(block);
        }

        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }

        public int GetBalance(string address)
        {
            int balance = 0;

            for (int i = 0; i < Chain.Count; i++)
            {
                for (int j = 0; j < Chain[i].Transactions.Count; j++)
                {
                    var transaction = Chain[i].Transactions[j];

                    if (transaction.FromAddress == address)
                    {
                        balance -= transaction.Amount;
                    }

                    if (transaction.ToAddress == address)
                    {
                        balance += transaction.Amount;
                    }
                }
            }

            return balance;
        }
    }
}