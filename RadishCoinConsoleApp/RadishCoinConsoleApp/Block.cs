using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public override string ToString()
        {
            return $"{this.Index}  + {this.TimeStamp} + {this.Data}+ {this.PreviousHash} + {this.Hash}";
        }

        public string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = $"{this.Index} + {this.PreviousHash} + {this.TimeStamp} + {this.Data}";

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData)) ;
                return Convert.ToBase64String(bytes) ;
            }
           
        }
    }

   
}
