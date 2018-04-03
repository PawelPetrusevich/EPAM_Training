using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankRepository
{
    using System.IO;

    public class BinnaryRepository : IRepository
    {
        private readonly string filePath;

        public BinnaryRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public bool CreateDeposit(Deposit deposit)
        {
            if (deposit == null)
            {
                throw new ArgumentNullException();
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(this.filePath, FileMode.Append)))
            {
                writer.Write(deposit.Id);
                writer.Write(deposit.Name);
                writer.Write(deposit.Balance);
                writer.Write(deposit.BonusBalance);
                writer.Write(deposit.Discont);
                writer.Write((int)deposit.CartType);
                return true;
            }
        }

        public bool RemoveDeposit(Deposit deposit)
        {
            throw new NotImplementedException();
        }

        public void AddDeposit(Deposit deposit, decimal summ)
        {
            throw new NotImplementedException();
        }

        public void DownDeposit(Deposit deposit, decimal summ)
        {
            throw new NotImplementedException();
        }
    }
}
