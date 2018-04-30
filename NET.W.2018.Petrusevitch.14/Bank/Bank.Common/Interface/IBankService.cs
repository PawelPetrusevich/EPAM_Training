// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file="IBankService.cs">
// Creator name: 
// Solution: Bank
// Project: Bank.Common
// </copyright>
// <summary>
// Filename: IBankService.cs
// Created day: 23.04.2018    19:09
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.Interface
{
    using System.Collections.Generic;

    using Bank.Common.Model;

    public interface IBankService
    {
        /// <summary>
        /// Create account.
        /// </summary>
        /// <param name="account">
        /// The new account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        bool CreateAccount(Account account);

        /// <summary>
        /// Remove account.
        /// </summary>
        /// <param name="id">
        /// The account id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        bool RemoveAccount(int id);

        /// <summary>
        /// Add balance.
        /// </summary>
        /// <param name="accountId">
        /// The account id.
        /// </param>
        /// <param name="sum">
        /// The sum.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        bool AddBalance(int accountId, decimal sum);

        /// <summary>
        /// The remove balance.
        /// </summary>
        /// <param name="accountId">
        /// The account id.
        /// </param>
        /// <param name="sum">
        /// The sum.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> boolean result.
        /// </returns>
        bool RemoveBalance(int accountId, decimal sum);

        /// <summary>
        /// The get accounts.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/> account list.
        /// </returns>
        List<Account> GetAccounts();
    }
}