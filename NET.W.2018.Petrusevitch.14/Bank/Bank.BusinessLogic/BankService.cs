namespace Bank.BusinessLogic
{
    using System;
    using System.Collections.Generic;

    using Bank.Common.Interface;
    using Bank.Common.Model;
    using Bank.Common.Validator;

    /// <summary>
    /// The bank service.
    /// </summary>
    public class BankService : IBankService
    {
        /// <summary>
        /// The bank repository.
        /// </summary>
        private readonly IBankRepository repository;

        /// <summary>
        /// The account model validator.
        /// </summary>
        private readonly AccountValidator accountValidator;

        public BankService(IBankRepository repository)
        {
            this.repository = repository;
            this.accountValidator = new AccountValidator();
        }

        /// <summary>
        /// The create account.
        /// </summary>
        /// <param name="account">
        /// The new account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checked
        /// </exception>
        /// <exception cref="ArgumentException">account with this id not found
        /// </exception>
        public bool CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            var temp = this.repository.FindById(account.Id);

            if (temp == null)
            {
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
            else
            {
                throw new ArgumentException($"Account with this ID is exist");
            }
        }

        /// <summary>
        /// The remove account.
        /// </summary>
        /// <param name="id">
        /// The account id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>bollean result.
        /// </returns>
        /// <exception cref="ArgumentException">id less as 0.
        /// </exception>
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

            return this.repository.UpdateAccount(account);
        }

        /// <summary>
        /// The add balance.
        /// </summary>
        /// <param name="accountId">
        /// The account id.
        /// </param>
        /// <param name="sum">
        /// The sum add balance.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentException">account id or sum is incorect
        /// </exception>
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

            return this.repository.UpdateAccount(account);
        }

        /// <summary>
        /// The remove balance.
        /// </summary>
        /// <param name="accountId">
        /// The account id.
        /// </param>
        /// <param name="sum">
        /// The sum remofe from balance.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentException">account id or sum is incorect.
        /// </exception>
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

            return this.repository.UpdateAccount(account);
        }

        /// <summary>
        /// The get accounts.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>account list.
        /// </returns>
        public List<Account> GetAccounts()
        {
            var result = this.repository.GetAccounts();

            if (result == null)
            {
                throw new InvalidOperationException("Bank have zero accounts");
            }

            return result;
        }
    }
}
