using System;

using BankExample.Domain;
using BankExample.Services;

namespace BankExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var response = new AccountService().AddMoney(1, 100);

            Console.WriteLine(response.IsSuccess()
                                  ? "The money was added"
                                  : ProcessError(response.Error));
        }

        private static string ProcessError(Exception ex)
            => ex switch
               {
                   AmountLessThanZeroException _ => "The money was not added, the account was closed",
                   { } e                         => e.Message
               };
    }
}