namespace BankExample.Domain
{
    public class Amount
    {
        private readonly decimal _value;

        public Amount(decimal value) => _value = value;

        public static Result<Amount> Create(decimal value)
            => value < 0
                   ? new Result<Amount>(new AmountLessThanZeroException())
                   : new Result<Amount>(new Amount(value));

        public static Amount operator +(Amount a,
                                        Amount b)
            => new Amount(a._value + b._value);
    }
}