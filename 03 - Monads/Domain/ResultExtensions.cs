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

        public static Result<R> ApplyIfSuccess2<T, R>(this Result<T> @this,
                                                      Func<T, Result<R>> fn)
            => @this.IsSuccess()
                   ? fn(@this.Value)
                   : new Result<R>(@this.Error);
    }
}