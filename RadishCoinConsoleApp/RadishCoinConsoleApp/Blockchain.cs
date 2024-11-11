using System;
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

        public Blockchain()
        {
            this.chain.Add(this.CreateGenesisBlock());
        }

        public Block CreateGenesisBlock()
        {
            return new Block(0, DateTime.Parse("01/01/2020"), "Genesis Block", "0");
        }

        public Block GetLatestBlock()
        {
            return this.chain[this.chain.Count - 1];
        }

        public void AddBlock(Block newBlock)
        {
            newBlock.PreviousHash = this.GetLatestBlock().Hash;
            newBlock.Hash = newBlock.CalculateHash();
            this.chain.Add(newBlock);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this.chain, Newtonsoft.Json.Formatting.Indented);
        }
    }
    

}
