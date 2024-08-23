using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class Statement : IStatements
    {
        private IAccount _account;

        public Statement(IAccount account)
        {
            _account = account;
        }

        public string GenerateStatement()
        {
            StringBuilder sb = new StringBuilder();
            List<Transaction> transactions = _account.GetTransactions();

            sb.AppendLine($"Date\t\t\t||Credit\t||Debit\t\t||Balance");

            
            foreach(Transaction t in transactions)
            {
                if(t.transactionType == TransactionType.credit)
                {
                    sb.AppendLine($"{t.DateTime}\t\t||{t.amount}\t\t||\t\t||{t.balance}");

                }
                else
                {
                    sb.AppendLine($"{t.DateTime}\t\t||\t\t||{t.amount}\t\t||{t.balance}");
                }

                //print overdraft request also haha
                

            }

            return sb.ToString();
        }

        
    }
}
