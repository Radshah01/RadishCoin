using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RadishCoinConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Blockchain RadishCoin = new Blockchain();
            RadishCoin.AddBlock(new Block(1, DateTime.Parse("10/10/2024"), "amount: 4"));
            RadishCoin.AddBlock(new Block(2, DateTime.Parse("11/11/2024"), "amount: 10"));

            Console.WriteLine(RadishCoin.ToString());
        }
    }
}
