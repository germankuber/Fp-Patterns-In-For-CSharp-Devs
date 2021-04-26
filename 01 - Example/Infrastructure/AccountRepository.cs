using BankExample.Domain;

namespace BankExample.Infrastructure
{
    public class AccountRepository
    {
        public Account GetById(int id)
            => new Account(100,
                           new Amount(id * 10),
                           true);
    }
}