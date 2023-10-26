namespace Sparky
{
    public class BankAccount
    {
        private readonly ILogBook _logbook;
        public int balance { get; set; }

        public BankAccount(ILogBook logbook)
        {
            balance = 0;
            _logbook = logbook;
        }

        public bool Deposit(int amount)
        {
            _logbook.Message("Deposit Invoke");
            balance += amount;

            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= balance)
            {
                _logbook.Message("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                return _logbook.LogBalanceAfterWithdrawal(balance);
            }

            return _logbook.LogBalanceAfterWithdrawal(balance - amount);
        }

        public int GetBalance()
        {
            _logbook.Message("GetBalance Invoke");
            return balance;
        }
    }
}
