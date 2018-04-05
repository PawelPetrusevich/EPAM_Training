namespace BankServices
{
    using System;
    using System.IO;
    using System.Linq;

    using BankRepository;

    /// <summary>
    /// The bank service.
    /// </summary>
    public class BankService : IService
    {
        private readonly string filePath;

        private readonly IRepository repository;

        public BankService(string path)
        {
            this.filePath = path;
            this.repository = new BinnaryRepository(filePath);
        }

        /// <summary>
        /// Create Deposit
        /// </summary>
        /// <param name="deposit">
        /// The deposit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        /// <exception cref="ArgumentNullException">null cheked
        /// </exception>
        public bool CreatDeposit(Deposit deposit)
        {
            if (deposit == null)
            {
                throw new ArgumentNullException(nameof(deposit));
            }

            if (this.repository.AllDeposits.Contains(deposit))
            {
                return false;
            }

            return this.repository.CreateDeposit(deposit);
        }

        /// <summary>
        /// The remove deposit.
        /// </summary>
        /// <param name="deposit">
        /// The deposit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        /// <exception cref="ArgumentNullException">null cheked
        /// </exception>
        public bool RemoveDeposit(Deposit deposit)
        {
            if (deposit == null)
            {
                throw new ArgumentNullException(nameof(deposit));
            }

            return this.repository.RemoveDeposit(deposit);
        }

        /// <summary>
        /// The up deposit.
        /// </summary>
        /// <param name="depositId">
        /// The deposit id.
        /// </param>
        /// <param name="summ">
        /// The summ for up deposit
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        public bool UpDeposit(int depositId, decimal summ)
        {
            var deposit = this.DepositInfo(depositId);

            this.repository.RemoveDeposit(deposit);

            deposit.BonusBalance += deposit.Discont * summ / 100;
            deposit.Balance += summ;

            return this.repository.CreateDeposit(deposit);
        }

        /// <summary>
        /// The down deposit.
        /// </summary>
        /// <param name="depositId">
        /// The deposit id.
        /// </param>
        /// <param name="summ">
        /// The summ to down balance
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        public bool DownDeposit(int depositId, decimal summ)
        {
            var deposit = this.DepositInfo(depositId);

            if (deposit.Balance < summ)
            {
                return false;
            }

            this.repository.RemoveDeposit(deposit);


            deposit.BonusBalance -= deposit.Discont * summ / 100;
            deposit.Balance -= summ;

            if (deposit.BonusBalance < 0)
            {
                deposit.BonusBalance = 0;
            }

            return this.repository.CreateDeposit(deposit);
        }

        /// <summary>
        /// Get deposit info
        /// </summary>
        /// <param name="depositId">
        /// The deposit id.
        /// </param>
        /// <returns>
        /// The <see cref="Deposit"/> searching deposit.
        /// </returns>
        /// <exception cref="ArgumentException">null cheked
        /// </exception>
        public Deposit DepositInfo(int depositId)
        {
            var deposit = this.repository.AllDeposits.SingleOrDefault(x => x.Id == depositId);

            if (deposit == null)
            {
                throw new ArgumentException(nameof(depositId));
            }

            return deposit;
        }
    }
}
