namespace Bank.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class BankTest
    {
        private readonly string path = AppDomain.CurrentDomain.BaseDirectory + "BankRepository.txt";

        [SetUp]
        public void InitializeMethod()
        {

        }
    }
}
