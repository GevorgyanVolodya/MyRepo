using System;

class TransferTransaction : Transaction
{
    private Account fromAccount;
    private Account toAccount;

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        : base(amount)
    {
        if (fromAccount == toAccount)
        {
            throw new ArgumentException("Cannot transfer to same account");
        }

        this.fromAccount = fromAccount;
        this.toAccount = toAccount;
    }

    public override void Execute()
    {
        fromAccount.Withdraw(Amount);
        toAccount.Deposit(Amount);

        fromAccount.AddTransaction(this);
        toAccount.AddTransaction(this);

        IsCompleted = true;
    }

    public bool IsOutgoing(Account account)
    {
        return account == fromAccount;
    }
}