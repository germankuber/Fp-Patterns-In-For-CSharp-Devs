using BankExample.Domain;

namespace BankExample.Infrastructure
{
    public class AccountRepository
    {
        public Result<Account> GetById(int id)
            => new Result<Account>(new Account(100,
                                               new Amount(id * 10),
                                               true));
    }
}