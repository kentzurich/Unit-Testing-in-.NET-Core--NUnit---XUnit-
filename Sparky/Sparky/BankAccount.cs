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
            _logbook.Message("Withdraw Invoke");
            if (amount <= balance )
            {
                balance -= amount;

                return true;
            }

            return false;
        }

        public int GetBalance()
        {
            _logbook.Message("GetBalance Invoke");
            return balance;
        }
    }
}
