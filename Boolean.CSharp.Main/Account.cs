using System.Transactions;

namespace Boolean.CSharp.Main
{
    public abstract class Account : IAccount
    {

        private List<Transaction> _transactions = new List<Transaction>();
        private int _ID;
        
        protected Account(int id)
        {
            _ID = id;
        }

        protected Account(int id, branch branch)
        {
            _ID = id;
            branchName = branch;
        }


        public void Deposit(decimal amount)
        {
            _transactions.Add(new Transaction(DateTime.Now.ToString("MM/dd/yyyy"), amount, TransactionType.credit, GetBalance() + amount));
        }

        public void Withdraw(decimal amount)
        {
            if ((GetBalance()) - amount + overdraftAmount > 0)
            {
                _transactions.Add(new Transaction(DateTime.Now.ToString("MM/dd/yyyy"), amount, TransactionType.debit, GetBalance() - amount));
                overdraftRequested = false;
            }
            
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public decimal GetBalance()
        {
            decimal sum = 0;
            foreach (Transaction t in _transactions)
            {
                sum += t.transactionType == TransactionType.credit ? t.amount : t.amount * (-1);
            }

            return sum;
        }

        public bool RequestOverdraft(int newOverdraft) 
        {
            bool requested = false;

            if (role == role.Customer)
            {
                overdraftRequested = true;
                GrantOverdraft(newOverdraft);
                requested =  true;
            }
            return requested;
        }

        public bool GrantOverdraft(int newOverdraft)
        {
            role = role.Manager;

            if (role == role.Manager)
            {
                Random rnd = new Random();
                int fiftyFifty = rnd.Next(1,3);
                if(fiftyFifty == 1)
                {
                    overdraftAmount = newOverdraft;
                    overdraftRequested = true;
                    return true;
                }
                
            }
            return false;
        }
        

        public role role { get; set; } = role.Customer;
        public branch branchName { get; set; }
        public TransactionType transactionType { get; set; }
        public bool overdraftRequested = false;
        public int overdraftAmount { get; set; } = 0;


    }
}
