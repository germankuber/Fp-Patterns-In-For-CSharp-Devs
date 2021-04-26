namespace BankExample.Domain
{
    public class Amount
    {
        private readonly decimal _value;

        public Amount(decimal value)
        {
            if (value < 0)
                throw new AmountLessThanZeroException();

            _value = value;
        }

        public static Amount operator +(Amount a,
                                        Amount b)
            => new Amount(a._value + b._value);
    }
}