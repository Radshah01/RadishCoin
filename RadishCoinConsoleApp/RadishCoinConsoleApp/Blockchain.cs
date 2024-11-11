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
            return this.chain[-1];
        }

        public void AddBlock(Block newBlock)
        {
            newBlock.PreviousHash = this.GetLatestBlock().Hash;
            newBlock.MineBlock(DifficultyEnum.VeryDifficult);
            this.chain.Add(newBlock);
        }

        public string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
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
