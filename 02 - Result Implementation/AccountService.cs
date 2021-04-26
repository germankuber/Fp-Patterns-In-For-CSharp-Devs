using BankExample.Domain;
using BankExample.Infrastructure;

namespace BankExample
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository = new AccountRepository();

        public Result<Amount> AddMoney(int idAccountOrigin,
                                       int idAccountDestination,
                                       decimal amount)
        {
            var accountResult = _accountRepository.GetById(idAccountOrigin);

            if (accountResult.IsSuccess())
            {
                var accountFrom = accountResult.Value;

                var accountTo = _accountRepository.GetById(idAccountDestination);

                if (accountTo.IsSuccess())
                {
                    var amountToAddResponse = Amount.Create(amount);

                    if (amountToAddResponse.IsSuccess())
                        accountFrom.AddMoney(amountToAddResponse.Value);
                    else
                        accountFrom?.CloseAccount();

                    return amountToAddResponse;
                }

                return new Result<Amount>(accountTo.Error);
            }

            return new Result<Amount>(accountResult.Error);
        }
    }
}