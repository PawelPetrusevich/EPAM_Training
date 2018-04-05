namespace Bank.Tests
{
    using System;
    using System.IO;

    using BankRepository;

    using BankServices;

    using NUnit.Framework;

    [TestFixture]
    public class BankTest
    {
        private readonly string path = AppDomain.CurrentDomain.BaseDirectory + "BankRepository.txt";

        [SetUp]
        public void InitializeMethod()
        {
            IService service = new BankService(this.path);
            service.CreatDeposit(new Deposit(1, "deposit1", 50, 0, CartType.Base));
            service.CreatDeposit(new Deposit(2, "deposit2", 1000, 160, CartType.Gold));
            service.CreatDeposit(new Deposit(3, "deposit3", 10000, 10, CartType.Platinum));
        }

        [TearDown]
        public void ClearTest()
        {
            File.Delete(this.path);
        }

        [Test]
        public void CreateNewDepositTest()
        {
            IService service = new BankService(this.path);
            var result = service.CreatDeposit(new Deposit(4, "deposit4", 100, 0, CartType.Gold));
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateNullDepositTest()
        {
            IService service = new BankService(this.path);
            Assert.Throws<ArgumentNullException>(() => service.CreatDeposit(null));
        }

        [Test]
        public void CreateDuplicateDepositTest()
        {
            IService service = new BankService(this.path);
            var result = service.CreatDeposit(new Deposit(2, "deposit2", 1000, 0, CartType.Gold));
            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveDeposit()
        {
            IService service = new BankService(this.path);
            var result = service.RemoveDeposit(new Deposit(2, "deposit2", 1000, 0, CartType.Gold));
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveNotExistDeposit()
        {
            IService service = new BankService(this.path);
            var result = service.RemoveDeposit(new Deposit(4, "deposit4", 100, 0, CartType.Gold));
            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveNullDeposit()
        {
            IService service = new BankService(this.path);
            Assert.Throws<ArgumentNullException>(() => service.RemoveDeposit(null));
        }

        [Test]
        public void UpDeposit()
        {
            IService service = new BankService(this.path);
            int depositId = 1;
            decimal summ = 600;
            var result = service.UpDeposit(depositId, summ);
            var resultDeposit = service.DepositInfo(depositId);

            var expectedDeposit = new Deposit(1, "deposit1", 650, 60, CartType.Base);

            Assert.That(resultDeposit.Balance, Is.EqualTo(expectedDeposit.Balance));
            Assert.That(resultDeposit.BonusBalance, Is.EqualTo(expectedDeposit.BonusBalance));
            Assert.IsTrue(result);
        }

        [Test]
        public void UpNotExistDeposit()
        {
            IService service = new BankService(this.path);
            Assert.Throws<ArgumentException>(() => service.UpDeposit(6, 600));
        }

        [Test]
        public void DownNotExistDeposit()
        {
            IService service = new BankService(this.path);
            Assert.Throws<ArgumentException>(() => service.DownDeposit(6, 600));
        }

        [Test]
        public void DownDeposit()
        {
            IService service = new BankService(this.path);
            int depositId = 2;
            decimal summ = 600;
            var result = service.DownDeposit(depositId, summ);
            var resultDeposit = service.DepositInfo(depositId);

            var expectedDeposit = new Deposit(2, "deposit2", 400, 40, CartType.Gold);

            Assert.That(resultDeposit.Balance, Is.EqualTo(expectedDeposit.Balance));
            Assert.That(resultDeposit.BonusBalance, Is.EqualTo(expectedDeposit.BonusBalance));
            Assert.IsTrue(result);
        }

        [Test]
        public void DownZeroDeposit()
        {
            IService service = new BankService(this.path);
            int depositId = 3;
            decimal summ = 600;
            var result = service.DownDeposit(depositId, summ);
            var resultDeposit = service.DepositInfo(depositId);

            var expectedDeposit = new Deposit(3, "deposit3", 9400, 0, CartType.Platinum);

            Assert.That(resultDeposit.Balance, Is.EqualTo(expectedDeposit.Balance));
            Assert.That(resultDeposit.BonusBalance, Is.EqualTo(expectedDeposit.BonusBalance));
            Assert.IsTrue(result);
        }

        [Test]
        public void DownSummBiggerAsBalanceDeposit()
        {
            IService service = new BankService(this.path);
            int depositId = 2;
            decimal summ = 6600;
            var result = service.DownDeposit(depositId, summ);

            Assert.IsFalse(result);
        }
    }
}
