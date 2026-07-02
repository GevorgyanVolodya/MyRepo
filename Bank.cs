using System.Collections.Generic;
using System;

class Bank
{
    private Dictionary<int, Account> accounts;
    private Queue<Transaction> pendingTransactions;
    private Stack<Transaction> executedTransactions;
    private int nextAccountId;

    public Bank()
    {
        accounts = new Dictionary<int, Account>();
        pendingTransactions = new Queue<Transaction>();
        executedTransactions = new Stack<Transaction>();
        nextAccountId = 1;
    }

    public Account CreateAccount()
    {
        Account account = new Account(nextAccountId);
        accounts.Add(account.Id, account);
        nextAccountId++;

        return account;
    }

    public void AddTransaction(Transaction transaction)
    {
        pendingTransactions.Enqueue(transaction);
    }

    public void ProcessTransactions()
    {
        while (pendingTransactions.Count > 0)
        {
            Transaction transaction = pendingTransactions.Dequeue();

            try
            {
                transaction.Execute();
                executedTransactions.Push(transaction);
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Transaction failed: {ex.Message}");
            }
        }
    }
}