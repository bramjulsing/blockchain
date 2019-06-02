using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BlockchainProgram
{
    public class Blockchain  
    {  
        public int Difficulty { set; get; } = 2;
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

        public void AddGenesisBlock()  
        {  
            Chain.Add(CreateGenesisBlock());  
        }
    
        public Block CreateGenesisBlock()  
        {  
            return new Block(DateTime.Now, null, null);  
        }
        
        public Block GetLatestBlock()  
        {  
            return Chain[Chain.Count - 1];  
        }
    
        public void AddBlock(Block block)  
        {  
            Block latestBlock = GetLatestBlock();  
            block.Index = latestBlock.Index + 1;  
            block.PreviousHash = latestBlock.Hash;  
            block.Mine(this.Difficulty);  
            Chain.Add(block);  
        }

        public void CreateTransaction(Transaction transaction)  
        {  
            PendingTransactions.Add(transaction);
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
    }
}