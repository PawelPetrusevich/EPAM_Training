namespace BankRepository
{
    using System;

    public class Deposit : IEquatable<Deposit>
    {

        public Deposit(int id, string name, decimal balance, decimal bonusBalance, CartType cart)
        {
            this.Id = id;
            this.Name = name;
            this.Balance = balance;
            this.CartType = cart;
            this.BonusBalance = bonusBalance;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal BonusBalance { get; set; }

        public decimal Balance { get; set; }

        public CartType CartType { get; set; }

        public int Discont => (int)this.CartType;

        public static bool operator ==(Deposit lhs, Deposit rhs)
        {
            if (object.ReferenceEquals(rhs, null))
            {
                return object.ReferenceEquals(lhs, null);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Deposit lhs, Deposit rhs)
        {
            return !(lhs == rhs);
        }

        public bool Equals(Deposit other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Deposit)obj);
        }

        public override int GetHashCode()
        {
            return new { this.Id, this.Name }.GetHashCode();
        }
    }
}