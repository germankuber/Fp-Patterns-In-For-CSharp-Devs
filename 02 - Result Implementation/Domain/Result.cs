using System;

namespace BankExample.Domain
{
    public class Result<T>
    {
        private readonly bool _isSuccess;

        public Result(Exception error)
        {
            Error = error;
            _isSuccess = false;
        }

        public Result(T value)
        {
            Value = value;
            _isSuccess = true;
        }

        public T Value { get; }
        public Exception Error { get; }

        public bool IsSuccess() => _isSuccess;
    }
}