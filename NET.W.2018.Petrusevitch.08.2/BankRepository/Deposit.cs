namespace BankRepository
{
    public class Deposit
    {

        public Deposit(int id, string name, decimal balance, CartType cart)
        {
            this.Id = id;
            this.Name = name;
            this.Balance = balance;
            this.CartType = cart;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal BonusBalance { get; set; }

        public decimal Balance { get; set; }

        public CartType CartType { get; set; }

        public int Discont => (int)this.CartType / 100;
    }
}