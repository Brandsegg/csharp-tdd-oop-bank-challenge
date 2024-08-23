using System.Transactions;

namespace Boolean.CSharp.Main
{
    public abstract class Account : IAccount
    {

        private List<Transaction> _transactions = new List<Transaction>();

        /*
        public Account()
        {
            List<Transaction> _transactions = new List<Transaction>();
        }
        */

        public void Deposit(decimal amount)
        {
            balance += amount;
            _transactions.Add(new Transaction(DateTime.Now.ToString("MM/dd/yyyy"), amount, TransactionType.credit, balance));
        }

        public void Withdraw(decimal amount)
        {
            if (balance - amount > 0)
            {
                balance -= amount;
                _transactions.Add(new Transaction(DateTime.Now.ToString("MM/dd/yyyy"), amount, TransactionType.debit, balance));
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

        private decimal balance { get; set; } //calculate based on transaction history

        public branch branch { get; set; }
        public TransactionType transactionType { get; set; }

        //public decimal GetBalance { get { return balance; } } //method instead?

    }
}
