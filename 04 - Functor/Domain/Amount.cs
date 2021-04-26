namespace BankExample.Domain
{
    public class Amount
    {
        public readonly decimal Value;

        public Amount(decimal value) => Value = value;

        public static Result<Amount> Create(decimal value)
            => value < 0
                   ? new Result<Amount>(new AmountLessThanZeroException())
                   : new Result<Amount>(new Amount(value));

        public static Amount operator +(Amount a,
                                        Amount b)
            => new Amount(a.Value + b.Value);
    }
}