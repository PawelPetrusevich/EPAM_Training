// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" FakeRepository.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.DataAccess    
// </copyright>
// <summary>
//  Filename: FakeRepository.cs
//  Created day: 23.04.2018    19:14
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.DataAccess
{
    using System.Collections.Generic;

    using Bank.Common.Model;

    public class FakeRepository
    {
        static FakeRepository()
        {
            Accounts = new List<Account>();
        }

        public static List<Account> Accounts;
    }
}