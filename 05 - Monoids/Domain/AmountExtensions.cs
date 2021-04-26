using System.Collections.Generic;
using System.Linq;

namespace BankExample.Domain
{
    public static class AmountExtensions
    {
        private static Amount Empty() => Amount.Create(0).Value;

        private static Amount MapPend(Amount a,
                                      Amount b) => Amount.Create(a.Value + b.Value).Value;

        public static Amount MConcat(this List<Amount> @this) =>
            @this.Aggregate(Empty(),
                            MapPend);
    }
}