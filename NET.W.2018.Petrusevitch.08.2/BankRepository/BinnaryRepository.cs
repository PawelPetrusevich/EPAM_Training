namespace BankRepository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The binnary repository.
    /// </summary>
    public class BinnaryRepository : IRepository
    {
        private readonly string filePath;

        public BinnaryRepository(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Gets the all deposits.
        /// </summary>
        public IEnumerable<Deposit> AllDeposits
        {
            get
            {
                if (!File.Exists(this.filePath))
                {
                    return new List<Deposit>();
                }

                using (BinaryReader reader = new BinaryReader(new FileStream(this.filePath, FileMode.Open)))
                {
                    var deposits = new List<Deposit>();
                    while (reader.PeekChar() > -1)
                    {
                        var id = reader.ReadInt32();
                        var name = reader.ReadString();
                        var balance = reader.ReadDecimal();
                        var bonusBalance = reader.ReadDecimal();
                        var cartType = (CartType)reader.ReadInt32();
                        deposits.Add(new Deposit(id, name, balance, bonusBalance, cartType));
                    }

                    return deposits;
                }
            }
        }

        /// <summary>
        /// The create new deposit
        /// </summary>
        /// <param name="deposit">
        /// The deposit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        /// <exception cref="ArgumentNullException">null cheked
        /// </exception>
        public bool CreateDeposit(Deposit deposit)
        {
            if (deposit == null)
            {
                throw new ArgumentNullException();
            }


            if (!File.Exists(this.filePath))
            {
                using (FileStream str = new FileStream(this.filePath, FileMode.Create))
                {
                }
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(this.filePath, FileMode.Append)))
            {
                writer.Write(deposit.Id);
                writer.Write(deposit.Name);
                writer.Write(deposit.Balance);
                writer.Write(deposit.BonusBalance);
                writer.Write((int)deposit.CartType);
                return true;
            }
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

            if (!File.Exists(this.filePath))
            {
                return false;
            }

            var deposits = this.AllDeposits.ToList();
            bool result = deposits.Remove(deposit);
            if (result)
            {
                using (FileStream str = new FileStream(this.filePath,FileMode.Create))
                {
                }
                foreach (var item in deposits)
                {
                    this.CreateDeposit(item);
                }
            }

            return result;
        }
    }
}
