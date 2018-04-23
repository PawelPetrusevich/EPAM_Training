// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" BankRepositoryTest.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Tests    
// </copyright>
// <summary>
//  Filename: BankRepositoryTest.cs
//  Created day: 23.04.2018    21:06
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Tests.Bank.DataAccess.Tests
{
    using global::Bank.Common.Enums;
    using global::Bank.Common.Model;
    using global::Bank.DataAccess;

    using NUnit.Framework;

    [TestFixture]
    public class BankRepositoryTest
    {
        [Test]
        public void AddAccountToFakeRepository()
        {
            var account = new Account { Id = 1111, AccountType = AccountType.Base, Balance = 0, Bonus = 0, FirstName = "Pety", LastName = "Pupkin" };

            var repository = new BankRepository();

            var result = repository.AddAccount(account);

            Assert.IsTrue(result);
        }
    }
}