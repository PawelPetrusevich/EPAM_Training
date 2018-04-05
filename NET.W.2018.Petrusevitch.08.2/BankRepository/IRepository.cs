namespace BankRepository
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IRepository
    {
        /// <summary>
        /// Gets the all deposits.
        /// </summary>
        IEnumerable<Deposit> AllDeposits { get; }

        /// <summary>
        /// The create deposit to binary file
        /// </summary>
        /// <param name="deposit">
        /// The deposit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        bool CreateDeposit(Deposit deposit);

        /// <summary>
        /// The remove deposit from binary file
        /// </summary>
        /// <param name="deposit">
        /// The deposit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        bool RemoveDeposit(Deposit deposit);
    }
}