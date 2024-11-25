using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace RadishCoinConsoleApp
{
    public class Blockchain
    {
        public List<Block> chain = new List<Block>();

        public List<Transaction> pendingTransactions = new List<Transaction>();

        public double miningPrize { get; set; } = 100d;

        public Blockchain()
        {
            this.chain.Add(this.CreateGenesisBlock());
        }

        public Block CreateGenesisBlock()
        {
            List<Transaction> TransactionList = new List<Transaction>();
            Transaction GenesisTransaction = new Transaction("Genesis", "GenesisReceiver", 0);
            TransactionList.Add(GenesisTransaction);

            return new Block(DateTime.Parse("01/01/2020"), TransactionList, "0");
        }

        public Block GetLatestBlock()
        {
            return this.chain[this.chain.Count -1];
        }

        //public void AddBlock(Block newBlock)
        //{
        //    Random rnd = new Random();
        //    newBlock.PreviousHash = this.GetLatestBlock().Hash;
        //    newBlock.MineBlock(DifficultyEnum.Difficult);
        //    this.chain.Add(newBlock);
        //}

        public void MinePendingTransactions(string miningPrizeAddress)
        {
            Random rnd = new Random();
            Block newBlock = new Block(DateTime.Now, this.pendingTransactions);
            Transaction newTransaction = new Transaction(null, miningPrizeAddress, this.miningPrize);

            newBlock.MineBlock((DifficultyEnum)rnd.Next(1,4)); 


            this.chain.Add(newBlock);
            this.pendingTransactions.Add(newTransaction);
        }

        public void CreateTransaction(Transaction transaction)
        {
            this.pendingTransactions.Add(transaction);
        }

        public double GetBalanceOfAddress(string address)
        {
            double balance = 0;

            foreach (Block block in this.chain)
            {
         
                foreach(Transaction trans in block.Transactions)
                {
                    if (trans.SenderAddress == address)
                    {
                        balance -= trans.Amount;
                    }

                   if (trans.ReceiverAddress == address)
                    {
                        balance += trans.Amount;
                    }
                }
            }
            Console.WriteLine($"{balance}");
            return balance;
        }


        public string ToJson()
        {
            return JsonConvert.SerializeObject(this.chain, Newtonsoft.Json.Formatting.Indented);
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < this.chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i-1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }
                else if (currentBlock.Hash != previousBlock.Hash){
                    return false;
                }
            }
            return true;
        }
    }
    

}
