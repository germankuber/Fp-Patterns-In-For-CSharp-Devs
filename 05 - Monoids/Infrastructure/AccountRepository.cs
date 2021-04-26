using System.Collections.Generic;

using BankExample.Domain;

namespace BankExample.Infrastructure
{
    public class AccountRepository
    {
        public Result<Account> GetById(int id)
            => new Result<Account>(new Account(100,
                                               Amount.Create(id * 10).Value,
                                               true));

        public Result<List<Amount>> GetAmountsById(int id)
            => default;
    }
}