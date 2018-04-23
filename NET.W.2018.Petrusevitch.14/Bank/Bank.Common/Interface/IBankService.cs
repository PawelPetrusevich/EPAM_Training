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
    using Bank.Common.Model;

    public interface IBankService
    {
        bool CreateAccount(Account account);

        bool RemoveAccount(int id);

        bool AddBalance(int accountId, decimal sum);

        bool RemoveBalance(int accountId, decimal sum);
    }
}