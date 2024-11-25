using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadishCoinConsoleApp
{
    public class Transaction
    {
        public string SenderAddress { get; set; }

        public string ReceiverAddress { get; set; }

        public double Amount { get; set; }


        public Transaction(string senderAddress, string receiverAddress, double amount)
        {
            this.SenderAddress = senderAddress;
            this.ReceiverAddress = receiverAddress;
            this.Amount = amount;
        }


    }
}
