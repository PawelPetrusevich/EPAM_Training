// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" IBankRepository.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Common    
// </copyright>
// <summary>
//  Filename: IBankRepository.cs
//  Created day: 23.04.2018    19:11
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.Interface
{
    using System.Collections.Generic;

    using Bank.Common.Model;

    /// <summary>
    /// The BankRepository interface.
    /// </summary>
    public interface IBankRepository
    {
        /// <summary>
        /// The add account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        bool AddAccount(Account account);

        /// <summary>
        /// The find by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Account"/>finding account.
        /// </returns>
        Account FindById(int id);

        /// <summary>
        /// The update account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> boolean result.
        /// </returns>
        bool UpdateAccount(Account account);

        /// <summary>
        /// The get accounts.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>account list.
        /// </returns>
        List<Account> GetAccounts();
    }
}