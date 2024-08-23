using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);

        decimal GetBalance();
        
        List<Transaction> GetTransactions();

        //Add branch here somehow

        bool RequestOverdraft(int newOverdraft);
        bool GrantOverdraft(int newOverdraft);
    }
}
