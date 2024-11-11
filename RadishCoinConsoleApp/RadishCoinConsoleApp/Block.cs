using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace RadishCoinConsoleApp
{
    public class Block
    {   
        public int Index { get; set; }

        public DateTime TimeStamp { get; set; }

        public object Data { get; set; }

        public string Hash { get; set; } = "";

        public string PreviousHash { get; set; } 

        public  DifficultyEnum Difficulty { get; set; }

        //randomize enum
        
        public int nonce { get; set; } = 0;


        public Block(int index, DateTime timeStamp, object data, string previousHash = "")
        {
            this.Index = index;
            this.TimeStamp = timeStamp;
            this.Data = data;
            this.PreviousHash = previousHash;
            this.Hash = this.CalculateHash();
        }

        public string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }

        //public override string ToString()
        //{
        //    return $"{this.Index}  + {this.TimeStamp} + {this.Data}+ {this.PreviousHash} + {this.Hash}";
        //}

        public string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = $"{this.Index} + {this.PreviousHash} + {this.TimeStamp} + {this.ToJson(this.Data)} + {this.nonce}";

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData)) ;
                return Convert.ToBase64String(bytes) ;
            }
           
        }


        public void MineBlock(DifficultyEnum difficulty)
        {
            string criteria = new string('0', (int)difficulty );
            while (this.Hash.Substring(0, (int)difficulty) != criteria)
            {
                this.nonce++;
                this.Hash = this.CalculateHash() ;

                
            }

            Console.WriteLine("Congrats! A block has been mined:\nMined Block Hash: " + this.Hash);
        }
    }

   
}
