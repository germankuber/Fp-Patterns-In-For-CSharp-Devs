using System;

using BankExample.Domain;

namespace BankExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                new AccountService().AddMoney(1, 1, 100);
                Console.WriteLine("The money was added");
            }
            catch (AmountLessThanZeroException)
            {
                Console.WriteLine("The money was not added, the account was closed");
            }
            catch (Exception e)
            {
                Console.WriteLine("The money was not added");
                Console.WriteLine(e.Message);
            }
        }
    }
}