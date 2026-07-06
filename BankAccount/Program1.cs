using System;

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        Account a1 = bank.CreateAccount();
        Account a2 = bank.CreateAccount();
        Account a3 = bank.CreateAccount();
        Account a4 = bank.CreateAccount();

        bank.AddTransaction(new DepositTransaction(a1, 1000));
        bank.AddTransaction(new DepositTransaction(a1, 500));
        bank.AddTransaction(new WithdrawTransaction(a1, 200));

        bank.AddTransaction(new DepositTransaction(a2, 1500));
        bank.AddTransaction(new WithdrawTransaction(a2, 300));

        bank.AddTransaction(new DepositTransaction(a3, 2000));
        bank.AddTransaction(new TransferTransaction(a3, a1, 400));
        bank.AddTransaction(new WithdrawTransaction(a3, 100));

        bank.AddTransaction(new DepositTransaction(a4, 800));
        bank.AddTransaction(new TransferTransaction(a4, a2, 200));
        bank.AddTransaction(new TransferTransaction(a1, a4, 250));

        bank.ProcessTransactions();

        Console.WriteLine("=== ACCOUNTS ===");

        PrintAccount(a1);
        PrintAccount(a2);
        PrintAccount(a3);
        PrintAccount(a4);
    }

    static void PrintAccount(Account account)
    {
        Console.WriteLine($"\nAccount {account.Id} | Balance: {account.Balance}");
        Console.WriteLine("Transactions:");

        foreach (Transaction transaction in account.Transactions)
        {
            if (transaction is TransferTransaction transfer)
            {
                if (transfer.IsOutgoing(account))
                {
                    Console.WriteLine($" - TransferTransaction | -{transaction.Amount} | {transaction.Date}");
                }
                else
                {
                    Console.WriteLine($" - TransferTransaction | +{transaction.Amount} | {transaction.Date}");
                }
            }
            else if (transaction is DepositTransaction)
            {
                Console.WriteLine($" - DepositTransaction | +{transaction.Amount} | {transaction.Date}");
            }
            else if (transaction is WithdrawTransaction)
            {
                Console.WriteLine($" - WithdrawTransaction | -{transaction.Amount} | {transaction.Date}");
            }
        }
    }
}
