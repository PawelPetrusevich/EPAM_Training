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
    using Bank.Common.Model;

    public interface IBankRepository
    {
        bool AddAccount(Account account);

        Account FindById(int id);
    }
}