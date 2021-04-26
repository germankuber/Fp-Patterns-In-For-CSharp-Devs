using System;

namespace BankExample.Domain
{
    public static class ResultExtensions
    {
        public static Result<T> ApplyIfSuccess<T>(this Result<T> @this,
                                                  Action<T> fn)
        {
            if (@this.IsSuccess())
                fn(@this.Value);

            return @this;
        }

        public static Result<TR> Bind<T, TR>(this Result<T> @this,
                                             Func<T, Result<TR>> fn)
            => @this.IsSuccess()
                   ? fn(@this.Value)
                   : new Result<TR>(@this.Error);

        public static Result<TR> Map<T, TR>(this Result<T> @this,
                                            Func<T, TR> fn)
            => @this.IsSuccess()
                   ? new Result<TR>(fn(@this.Value))
                   : new Result<TR>(@this.Error);
    }
}