using BankExample.Domain;
using BankExample.Infrastructure;

namespace BankExample.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository = new AccountRepository();
        private readonly AmountLogService _amountLogService = new AmountLogService();

        private Result<Amount> AddMoney(Account account,
                                        decimal amount)
            => Amount.Create(amount)
                     .ApplyIfSuccess2(account.AddMoney);

        public Result<Amount> AddMoney(int idAccountOrigin,
                                       decimal amount)
        {
            var result = _accountRepository.GetById(idAccountOrigin)
                                           .ApplyIfSuccess2(accountFrom => AddMoney(accountFrom, amount))
                                           .ApplyIfSuccess2(accountFrom
                                                                => _amountLogService.Log(new AmountLog(accountFrom)));

            return result.IsSuccess()
                       ? new Result<Amount>(result.Value.Amount)
                       : new Result<Amount>(result.Error);
        }

        //public Result<Amount> AddMoney(int idAccountOrigin,
        //                               int idAccountDestination,
        //                               decimal amount)
        //{
        //    var accountResult = _accountRepository.GetById(idAccountOrigin);

        //    if (accountResult.IsSuccess())
        //    {
        //        var accountFrom = accountResult.Value;

        //        var accountTo = _accountRepository.GetById(idAccountDestination);

        //        if (accountTo.IsSuccess())
        //        {
        //            var amountToAddResponse = Amount.Create(amount);

        //            if (amountToAddResponse.IsSuccess())
        //            {
        //                var response = accountFrom.AddMoney(amountToAddResponse.Value);

        //                if (response.IsSuccess())
        //                    _amountLogService.Log(new AmountLog(response.Value));
        //                else
        //                    return response;
        //            }
        //            else
        //            {
        //                accountFrom?.CloseAccount();
        //            }

        //            return amountToAddResponse;
        //        }

        //        return new Result<Amount>(accountTo.Error);
        //    }

        //    return new Result<Amount>(accountResult.Error);
        //}
    }
}