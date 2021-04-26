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
                                 .Bind(amountResult => Amount.Create(amountResult.Amount.Value));

        private Result<Amount> AddMoney(Account account,
                                        decimal amount)
            => Amount.Create(amount)
                     .Bind(account.AddMoney);

        public Result<Amount> GetTotalOfAmounts(int idAccount)
            => _accountRepository.GetAmountsById(idAccount)
                                 .Map(amountsList => amountsList.MConcat());
    }
}