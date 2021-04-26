using BankExample.Domain;
using BankExample.Infrastructure;

namespace BankExample.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository = new AccountRepository();
        private readonly AmountLogService _amountLogService = new AmountLogService();

        public Result<Amount> AddMoney(int idAccountOrigin,
                                       decimal amount)
            => _accountRepository.GetById(idAccountOrigin)
                                 .Bind(accountFrom => AddMoney(accountFrom, amount))
                                 .Map(accountFrom => new AmountLog(accountFrom))
                                 .Bind(accountFrom => _amountLogService.Log(accountFrom))
                                 .Map(amountResult => new Amount(amountResult.Amount.Value));

        private Result<Amount> AddMoney(Account account,
                                        decimal amount)
            => Amount.Create(amount)
                     .Bind(account.AddMoney);
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