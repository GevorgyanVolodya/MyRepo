class DepositTransaction : Transaction
{
    private Account account;

    public DepositTransaction(Account account, decimal amount)
        : base(amount)
    {
        this.account = account;
    }

    public override void Execute()
    {
        account.Deposit(Amount);
        account.AddTransaction(this);

        IsCompleted = true;
    }
}