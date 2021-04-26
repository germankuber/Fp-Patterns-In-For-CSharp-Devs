using System;

using BankExample.Domain;
using BankExample.Infrastructure;

namespace BankExample
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository = new AccountRepository();

        public void AddMoney(int idAccountOrigin,
                             int idAccountDestination,
                             decimal amount)
        {
            Account accountFrom = default;

            try
            {
                accountFrom = _accountRepository.GetById(idAccountOrigin);

                if (accountFrom != null)
                {
                    var accountTo = _accountRepository.GetById(idAccountDestination);

                    if (accountTo != null)
                    {
                        var amountToAdd = new Amount(amount);

                        accountFrom.AddMoney(amountToAdd);
                    }
                }
            }
            catch (AmountLessThanZeroException e)
            {
                accountFrom?.CloseAccount();
                Console.WriteLine(e);

                throw;
            }
        }
    }
}