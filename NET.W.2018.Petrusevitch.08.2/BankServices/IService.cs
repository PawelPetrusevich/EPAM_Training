namespace BankServices
{
    using BankRepository;

    public interface IService
    {
        /// <summary>
        /// The creat deposit.
        /// </summary>
        /// <param name="deposit">
        /// The deposit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        bool CreatDeposit(Deposit deposit);

        /// <summary>
        /// The remove deposit.
        /// </summary>
        /// <param name="deposit">
        /// The deposit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        bool RemoveDeposit(Deposit deposit);

        /// <summary>
        /// The up deposit.
        /// </summary>
        /// <param name="depositId">
        /// The deposit id.
        /// </param>
        /// <param name="summ">
        /// The summ to up balance
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        bool UpDeposit(int depositId, decimal summ);

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
        bool DownDeposit(int depositId, decimal summ);

        /// <summary>
        /// Get deposit info by id
        /// </summary>
        /// <param name="depositId">
        /// The deposit id.
        /// </param>
        /// <returns>
        /// The <see cref="Deposit"/> searching deposit.
        /// </returns>
        Deposit DepositInfo(int depositId);
    }
}