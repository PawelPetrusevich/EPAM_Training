using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    using System.Runtime.CompilerServices;

    using Bank.BusinessLogic;
    using Bank.Common.Enums;
    using Bank.Common.Interface;
    using Bank.Common.Model;

    using Ninject;

    class Program
    {
        private static readonly IBankService service;

        static Program()
        {
            IKernel kernel = new StandardKernel(new NinjectConfiguration());
            service = kernel.Get<IBankService>();
        }

        static void Main(string[] args)
        {
            service.CreateAccount(
                new Account
                    {
                        AccountType = AccountType.Base,
                        Balance = 300,
                        FirstName = "Vasya",
                        LastName = "Pupkin"
                    });

            service.CreateAccount(
                new Account
                    {
                        AccountType = AccountType.Gold,
                        Balance = 500,
                        FirstName = "pasha",
                        LastName = "vaskin"
                    });

            service.CreateAccount(
                new Account
                    {
                        AccountType = AccountType.Silver,
                        Balance = 400,
                        FirstName = "sasha",
                        LastName = "pashkin"
                    });

            var account = service.GetAccounts();

            foreach (var item in account)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Add balance");

            foreach (var item in account)
            {
                service.AddBalance(item.Id, 50);
            }

            foreach (var item in account)
            {
                Console.WriteLine(item);
            }

            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine("Remove balance");

            foreach (var item in account)
            {
                service.RemoveBalance(item.Id, 50);
            }

            foreach (var item in account)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
    }
}
