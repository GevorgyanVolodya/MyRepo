class WithdrawTransaction : Transaction
{
    private Account account;

    public WithdrawTransaction(Account account, decimal amount)
        : base(amount)
    {
        this.account = account;
    }

    public override void Execute()
    {
        account.Withdraw(Amount);

        account.AddTransaction(this);

        IsCompleted = true;
    }
}