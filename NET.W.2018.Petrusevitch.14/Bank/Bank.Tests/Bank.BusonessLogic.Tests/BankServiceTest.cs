// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" BankServiceTest.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Tests    
// </copyright>
// <summary>
//  Filename: BankServiceTest.cs
//  Created day: 23.04.2018    19:20
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Tests.Bank.BusonessLogic.Tests
{
    using System;

    using global::Bank.BusinessLogic;
    using global::Bank.Common.Enums;
    using global::Bank.Common.Interface;
    using global::Bank.Common.Model;
    using global::Bank.DataAccess;

    using Moq;

    using Ninject;

    using NUnit.Framework;
    using NUnit.Framework.Internal;

    [TestFixture]
    public class BankServiceTest
    {
        Mock<IBankRepository> mockBankRepository = new Mock<IBankRepository>();

        private IBankService service;

        [SetUp]
        public void Initialize()
        {
            this.mockBankRepository.Setup(x => x.AddAccount(It.IsAny<Account>())).Returns(true);
            this.mockBankRepository.Setup(x => x.AddAccount(null)).Throws<ArgumentNullException>();
            this.mockBankRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Account());

            this.service = new BankService(this.mockBankRepository.Object);
        }


        [Test]
        public void CreateAccountTest()
        {
            var account = new Account { Id = 1111, AccountType = AccountType.Base, Balance = 0, Bonus = 0, FirstName = "Pety", LastName = "Pupkin" };

            var result = this.service.CreateAccount(account);

            Assert.IsTrue(result);
        }

        [Test]
        public void CreatAccountExeptionNullTest()
        {
            Account account = null;

            Assert.Throws<ArgumentNullException>(() => this.service.CreateAccount(account));
        }

        [Test]
        public void CreateAccountValidExeptionTest()
        {
            var account = new Account { Id = 1111, LastName = "Pupkin" };

            Assert.Throws<ArgumentException>(() => this.service.CreateAccount(account));
        }

        [Test]
        public void RemoveAccountTest()
        {
            var id = 3;

            var result = this.service.RemoveAccount(id);

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveIdExeptionTest()
        {
            var id = -1;

            Assert.Throws<ArgumentException>(() => this.service.RemoveAccount(id));
        }

        [Test]
        public void AddBalanceTest()
        {
            var id = 1;

            var sum = 20;

            this.mockBankRepository.Setup(x => x.FindById(1)).Returns(new Account() { Balance = 50 });

            var result = this.service.AddBalance(id, sum);

            Assert.IsTrue(result);
        }

        [Test]
        public void AddBalanceExeptionTest()
        {
            var id = -1;

            var sum = 20;

            Assert.Throws<ArgumentException>(() => this.service.AddBalance(id, sum));
        }

        [Test]
        public void RemoveBalanceFalseTest()
        {
            var id = 1;

            var sum = 70;

            this.mockBankRepository.Setup(x => x.FindById(1)).Returns(new Account() { Balance = 50, AccountType = AccountType.Silver });

            var result = this.service.RemoveBalance(id, sum);

            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveBalanceTrueTest()
        {
            var id = 1;

            var sum = 20;

            this.mockBankRepository.Setup(x => x.FindById(1)).Returns(new Account() { Balance = 50, AccountType = AccountType.Base });

            var result = this.service.RemoveBalance(id, sum);

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveBalanceExeptionTest()
        {
            var id = -11;

            var sum = 70;

            Assert.Throws<ArgumentException>(() => this.service.RemoveBalance(id, sum));
        }
    }
}