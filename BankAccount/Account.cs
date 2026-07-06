using System.Collections.Generic;
using System;

class Account
{
    public int Id { get; }
    public decimal Balance { get; private set; }
    public List<Transaction> Transactions { get; }

    public Account(int id)
    {
        Id = id;
        Balance = 0;
        Transactions = new List<Transaction>();
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (Balance < amount)
        {
            throw new InvalidOperationException("Not enough balance");
        }

        Balance -= amount;
    }

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }
}
