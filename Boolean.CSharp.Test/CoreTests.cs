using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void BranchTest()
        {
            CurrentAccount curr = new CurrentAccount();

            curr.branch = branch.Oslo;

            Assert.That(curr.branch, Is.Not.Null);
        }

        [Test]
        public void DepositTest()
        {
            CurrentAccount curr = new CurrentAccount();

            curr.Deposit(100.0M);

            decimal expected = 100.0M;

            decimal result = curr.GetBalance();

            Assert.That(expected == result);
        }

        [TestCase(100.0, 50.0, 50.0, true)]
        [TestCase(100.0, 50.0, 30.0, false)]
        [TestCase(50.0, 30.0, 20.0, true)]
        [TestCase(50.0, 100.0, 50.0, true)] //withdraw more than available

        public void WithdrawTest(decimal depositAmount, decimal withdrawAmount, decimal expectedAmount, bool expectedResult)
        {
            CurrentAccount curr = new CurrentAccount();

            curr.Deposit(depositAmount);
            curr.Withdraw(withdrawAmount);

            decimal expectedBalance = expectedAmount;

            decimal actualBalance = curr.GetBalance();
               
            bool result = actualBalance == expectedBalance;
                 
            Assert.That(expectedResult == result);
        }

        [Test]
        public void StatementTest()
        {
            IAccount curr = new CurrentAccount();
            IStatements statement = new Statement(curr);


            curr.Deposit(100.0M);
            curr.Withdraw(50.0M);
            curr.Deposit(2000M);

            Transaction t = curr.GetTransactions().First();

            //string expected = $"{t.DateTime}\t\t||\t\t||{t.amount}\t\t||{t.balance}";
            string expected = $"||";

            //Act 
            string result = statement.GenerateStatement();

            Assert.That(result, Does.Contain(expected));
        }

        [Test]
        public void NewCalculateBalanceTest()
        {
            IAccount curr = new CurrentAccount();
            IStatements statement = new Statement(curr);

            curr.Deposit(100.0M);
            curr.Withdraw(50.0M);
            curr.Deposit(2000M);

            Transaction t = curr.GetTransactions().First();

            //string expected = $"{t.DateTime}\t\t||\t\t||{t.amount}\t\t||{t.balance}";
            decimal expected = 2050M;

            //Act 
            decimal result = curr.GetBalance();

            Assert.That(expected == result);
        }

    }
}