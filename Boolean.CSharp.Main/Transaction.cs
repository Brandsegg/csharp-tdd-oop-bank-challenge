using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    //I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
    public class Transaction
    {

        public Transaction(string dateTime, decimal amount, TransactionType transactionType, decimal balance) 
        {   
            this.DateTime = dateTime;
            this.transactionType = transactionType;
            this.balance = balance;
            this.amount = amount;
            
        }

        public string DateTime { get; set; }
        public decimal amount { get; set; }
        public decimal balance { get; set; }
        public TransactionType transactionType { get; set; }

        
    }
}
