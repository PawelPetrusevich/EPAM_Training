using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
    using System.Data.Entity;

    using Bank.Common.Interface;
    using Bank.Common.Model;

    public class BankRepository : IBankRepository, IDisposable
    {
        private readonly DbContext context;

        private readonly DbSet<Account> dbSet;

        private bool dispose;

        public BankRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Account>();
        }

        ~BankRepository()
        {
            this.Dispose(false);
        }

        public List<Account> Accounts { get; set; }

        public bool AddAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            var result = this.dbSet.Add(account);
            this.context.SaveChanges();

            if (result == null)
            {
                return false;
            }

            return true;
        }

        public Account FindById(int id)
        {
            var account = this.dbSet.SingleOrDefault(x => x.Id == id);

            return account;
        }

        public bool UpdateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            this.context.Entry(account).State = EntityState.Modified;
            this.context.SaveChanges();
            return true;
        }

        public bool DeleteAccount(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            var account = this.dbSet.SingleOrDefault(x => x.Id == id);
            if (account == null)
            {
                return false;
            }

            this.dbSet.Remove(account);
            this.context.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool flag)
        {
            if (this.dispose)
            {
                return;
            }

            this.context.Dispose();
            this.dispose = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
