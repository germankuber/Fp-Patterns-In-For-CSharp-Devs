namespace BankExample.Domain
{
    public class Account
    {
        public Account(int id,
                       Amount amount,
                       bool open)
        {
            Id = id;
            Amount = amount;
            Open = open;
        }

        public int Id { get; set; }
        public Amount Amount { get; set; }
        public bool Open { get; set; }

        public Result<Amount> AddMoney(Amount amount)
        {
            if (!Open)
                return new Result<Amount>(new AccountClosedException());

            Amount += amount;

            return new Result<Amount>(amount);
        }

        public Result<Account> CloseAccount()
        {
            if (!Open)
                return new AccountAlreadyClosedException();

            Open = false;

            return new Result<Account>(this);
        }
    }
}