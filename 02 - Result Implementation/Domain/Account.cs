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

        public void AddMoney(Amount amount)
        {
            if (!Open)
                throw new AccountClosedException();

            Amount += amount;
        }

        public void CloseAccount()
        {
            if (!Open)
                throw new AccountAlreadyClosedException();

            Open = false;
        }
    }
}