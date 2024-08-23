// See https://aka.ms/new-console-template for more information


using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;

IAccount curr = new CurrentAccount();
IStatements statement = new Statement(curr);

curr.Deposit(100.0M);
curr.Withdraw(50.0M);
curr.Deposit(100.0M);
curr.Withdraw(50.0M);
curr.Deposit(100.0M);
curr.Withdraw(50.0M);
curr.Deposit(200.0M);
curr.Deposit(300.0M);


string statementString = statement.GenerateStatement();

Console.WriteLine(statementString);

Console.WriteLine(curr.GetBalance());

