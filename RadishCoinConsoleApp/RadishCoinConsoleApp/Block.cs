using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace RadishCoinConsoleApp
{
    public class Block
    {   
        public int Index { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Data { get; set; }

        public string Hash { get; set; } = "";

        public string PreviousHash { get; set; }


        public Block(int index, DateTime timeStamp, string data, string previousHash = "")
        {
            this.Index = index;
            this.TimeStamp = timeStamp;
            this.Data = data;
            this.PreviousHash = previousHash;
            this.Hash = this.CalculateHash();
            
        }


        public string CalculateHash()
        {
            SHA256 hash = SHA256.Create(this.Index.ToString() + this.PreviousHash + this.TimeStamp.ToString() + this.Data);
            return hash.ToString();
        }
    }

   
}
