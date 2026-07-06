using System;

abstract class Transaction
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }
    public bool IsCompleted { get; protected set; }

    protected Transaction(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive");
        }

        Id = Guid.NewGuid();
        Amount = amount;
        Date = DateTime.Now;
        IsCompleted = false;
    }

    public abstract void Execute();
}