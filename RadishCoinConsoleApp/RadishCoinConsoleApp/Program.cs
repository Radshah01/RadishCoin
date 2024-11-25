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
            RadishCoin.CreateTransaction(new Transaction("address1", "address2", 100));
            RadishCoin.CreateTransaction(new Transaction("address2", "address1", 20 ));


            Console.WriteLine("\n******** Starting the miner! ********\n\n");

            RadishCoin.MinePendingTransactions("address1");

            Console.WriteLine("\nBalance of address1 is: " + RadishCoin.GetBalanceOfAddress("address1"));
        


            Console.WriteLine("\n\n----------------------------------------------------------------------\n\n******** Starting the miner again! ********\n\n");

            RadishCoin.MinePendingTransactions("address2");

            Console.WriteLine("\nBalance of address2 is: " + RadishCoin.GetBalanceOfAddress("address2"));



    

            //RadishCoin.AddBlock(new Block(1, DateTime.Parse("10/10/2024"), transaction));
            //RadishCoin.AddBlock(new Block(2, DateTime.Parse("11/11/2024"), transaction2));



            //for (int i = 0; i < RadishCoin.chain.Count; i++) {
            //    Console.WriteLine(RadishCoin.chain[i].ToString());
            //}

            //Console.WriteLine(RadishCoin.ToJson(RadishCoin.chain));

            //Console.WriteLine("Wait for each Block to be mined!\n");
            //Console.WriteLine("Block 1 is being mined...");
            //RadishCoin.AddBlock(new Block(1, DateTime.Parse("10/10/2024"), transaction));
            //Console.WriteLine("Difficulty: " + RadishCoin.GetLatestBlock().Hash + RadishCoin.GetLatestBlock().PreviousHash + RadishCoin.GetLatestBlock().Difficulty);


            //Console.WriteLine("Wait for each Block to be mined!\n");
            //Console.WriteLine("Block 1 is being mined...");
            //RadishCoin.AddBlock(new Block(1, DateTime.Parse("10/10/2024"), transaction));
            //Console.WriteLine("Difficulty: " + RadishCoin.GetLatestBlock().Hash + RadishCoin.GetLatestBlock().PreviousHash + RadishCoin.GetLatestBlock().Difficulty);



            //Console.WriteLine("\n\nBlock 2 is being mined...");
            //RadishCoin.AddBlock(new Block(1, DateTime.Parse("11/11/2024"), transaction2));
            //Console.WriteLine("Difficulty: " + RadishCoin.GetLatestBlock().Hash + RadishCoin.GetLatestBlock().PreviousHash + RadishCoin.GetLatestBlock().Difficulty);

            //Console.WriteLine("\n\nBlock 3 is being mined...");
            //RadishCoin.AddBlock(new Block(3, DateTime.Parse("11/12/2024"), transaction2));
            //Console.WriteLine("Difficulty: " + RadishCoin.GetLatestBlock().Hash + RadishCoin.GetLatestBlock().PreviousHash + RadishCoin.GetLatestBlock().Difficulty);


            //Console.WriteLine("\n\nBlock 4 is being mined...");
            //RadishCoin.AddBlock(new Block(2, DateTime.Parse("09/12/2024"), transaction2));
            //Console.WriteLine("Difficulty: " + RadishCoin.GetLatestBlock().Hash + RadishCoin.GetLatestBlock().PreviousHash + RadishCoin.GetLatestBlock().Difficulty);

            //Console.WriteLine(RadishCoin.ToJson());

            Console.ReadLine();

        }
    }
}
