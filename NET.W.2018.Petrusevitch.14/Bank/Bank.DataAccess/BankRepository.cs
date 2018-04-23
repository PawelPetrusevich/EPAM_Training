using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
    using Bank.Common.Interface;
    using Bank.Common.Model;

    public class BankRepository : IBankRepository
    {
        public BankRepository()
        {
            this.Accounts = FakeRepository.Accounts;
        }

        public List<Account> Accounts { get; set; }

        public bool AddAccount(Account account)
        {
            if (account  == null)
            {
                throw new ArgumentNullException();
            }

            this.Accounts.Add(account);

            return true;
        }

        public Account FindById(int id)
        {
            var account = this.Accounts.SingleOrDefault(x => x.Id == id);

            return account;
        }
    }
}
