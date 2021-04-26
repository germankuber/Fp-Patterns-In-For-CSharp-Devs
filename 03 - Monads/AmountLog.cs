using BankExample.Domain;

namespace BankExample
{
    public class AmountLog
    {
        public AmountLog(Amount amount) => Amount = amount;

        public Amount Amount { get; set; }
    }
}