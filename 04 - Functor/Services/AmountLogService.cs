using BankExample.Domain;

namespace BankExample.Services
{
    public class AmountLogService
    {
        public Result<AmountLog> Log(AmountLog toLog) => new Result<AmountLog>(toLog);
    }
}