namespace BankRepository
{
    public interface IRepository
    {
        bool CreateDeposit(Deposit deposit);

        bool RemoveDeposit(Deposit deposit);

        void AddDeposit(Deposit deposit, decimal summ);

        void DownDeposit(Deposit deposit,decimal summ);
    }
}