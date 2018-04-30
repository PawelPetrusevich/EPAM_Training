namespace Bank.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Bank.Common.Interface;
    using Bank.Common.Model;

    /// <summary>
    /// The bank repository.
    /// </summary>
    public class BankRepository : IBankRepository, IDisposable
    {
        /// <summary>
        /// The bank context.
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// The account dbset.
        /// </summary>
        private readonly DbSet<Account> dbSet;

        /// <summary>
        /// The dispose flag.
        /// </summary>
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

        /// <summary>
        /// Create account.
        /// </summary>
        /// <param name="account">
        /// The new account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checked.
        /// </exception>
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

        /// <summary>
        /// Find account by id.
        /// </summary>
        /// <param name="id">
        /// The account id.
        /// </param>
        /// <returns>
        /// The <see cref="Account"/>finding account.
        /// </returns>
        public Account FindById(int id)
        {
            var account = this.dbSet.SingleOrDefault(x => x.Id == id);

            return account;
        }

        /// <summary>
        /// The update account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null cheked.
        /// </exception>
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

        /// <summary>
        /// The get accounts.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>accounts list.
        /// </returns>
        public List<Account> GetAccounts()
        {
            return this.dbSet.ToList();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// The dispose pattern
        /// </summary>
        /// <param name="flag">
        /// The flag.
        /// </param>
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
