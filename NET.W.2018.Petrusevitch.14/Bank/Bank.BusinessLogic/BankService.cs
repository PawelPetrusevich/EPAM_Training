using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BusinessLogic
{
    using Bank.Common.Interface;
    using Bank.Common.Model;
    using Bank.Common.Validator;

    using FluentValidation;

    public class BankService : IBankService
    {
        private readonly IBankRepository repository;

        private readonly AccountValidator accountValidator;

        public BankService(IBankRepository repository)
        {
            this.repository = repository;
            this.accountValidator = new AccountValidator();
        }

        public bool CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            var temp = this.repository.FindById(account.Id);

            if (temp.Id == account.Id)
            {
                throw new ArgumentException($"Account with this ID is exist");
            }

            var valid = this.accountValidator.Validate(account);

            if (!valid.IsValid)
            {
                foreach (var error in valid.Errors)
                {
                    throw new ArgumentException($"{error.PropertyName} is invalid.");
                }
            }

            return this.repository.AddAccount(account);
        }

        public bool RemoveAccount(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var account = this.repository.FindById(id);

            if (account == null)
            {
                throw new ArgumentException($"Account with this ID not found");
            }

            account.IsDelete = true;

            return true;
        }

        public bool AddBalance(int accountId, decimal sum)
        {
            if (accountId <= 0)
            {
                throw new ArgumentException(nameof(accountId));
            }

            if (sum <= 0)
            {
                throw new ArgumentException(nameof(sum));
            }

            var account = this.repository.FindById(accountId);

            account.Balance = account.Balance + sum;

            return true;
        }

        public bool RemoveBalance(int accountId, decimal sum)
        {
            if (accountId <= 0)
            {
                throw new ArgumentException(nameof(accountId));
            }

            if (sum <= 0)
            {
                throw new ArgumentException(nameof(sum));
            }

            var account = this.repository.FindById(accountId);

            if (sum > account.Balance)
            {
                return false;
            }

            account.Balance = account.Balance - sum;

            return true;
        }
    }
}
