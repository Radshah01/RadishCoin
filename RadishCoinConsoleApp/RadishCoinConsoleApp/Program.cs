using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


            object transaction = new { amount = 4 };
            object transaction2 = new { amount = 22 };

            //RadishCoin.AddBlock(new Block(1, DateTime.Parse("10/10/2024"), transaction));
            //RadishCoin.AddBlock(new Block(2, DateTime.Parse("11/11/2024"), transaction2));



            //for (int i = 0; i < RadishCoin.chain.Count; i++) {
            //    Console.WriteLine(RadishCoin.chain[i].ToString());
            //}

            //Console.WriteLine(RadishCoin.ToJson(RadishCoin.chain));

            Console.WriteLine("Wait for each Block to be mined!\n");
            Console.WriteLine("Block 1 is being mined...");
            RadishCoin.AddBlock(new Block(1, DateTime.Parse("10/10/2024"), transaction));
            Console.WriteLine("Difficulty: " + RadishCoin.GetLatestBlock().Hash + RadishCoin.GetLatestBlock().PreviousHash + RadishCoin.GetLatestBlock().Difficulty);

            Console.WriteLine("\n\nBlock 2 is being mined...");
            RadishCoin.AddBlock(new Block(2, DateTime.Parse("11/11/2024"), transaction2));
            Console.WriteLine("Difficulty: " + RadishCoin.GetLatestBlock().Hash + RadishCoin.GetLatestBlock().PreviousHash + RadishCoin.GetLatestBlock().Difficulty);

            Console.ReadLine();

        }
    }
}
