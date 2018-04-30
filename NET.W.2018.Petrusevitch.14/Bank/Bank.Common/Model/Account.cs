// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" Account.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Common
//  Filename: Account.cs
//  Created day: 23.04.2018    19:01
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.Model
{
    using System;

    using Bank.Common.Enums;

    /// <summary>
    /// The account.
    /// </summary>
    public class Account
    {
        private decimal balance;

        public Account()
        {
            this.BonusOnChange += this.BonusChange;
        }


        /// <summary>
        /// The bonus on change event.
        /// </summary>
        public event EventHandler<decimal> BonusOnChange;

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Balance
        {
            get => this.balance;

            set
            {
                this.balance = value;
                this.BonusChange(value);
            }
            
        }

        public int Bonus { get; set; } = 0;

        public AccountType AccountType { get; set; } = AccountType.Base;

        public bool IsDelete { get; set; } = false;

        /// <summary>
        /// The to string override.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> account string.
        /// </returns>
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName}  Balance: {this.Balance}  Bonus: {this.Bonus}";
        }

        /// <summary>
        /// The bonus change.
        /// </summary>
        /// <param name="sum">
        /// The sum.
        /// </param>
        private void BonusChange(decimal sum)
        {
            EventHandler<decimal> handler = this.BonusOnChange;

            handler?.Invoke(this, sum);
        }

        /// <summary>
        /// The bonus change methods.
        /// </summary>
        /// <param name="e">
        /// The object sender.
        /// </param>
        /// <param name="sum">
        /// The sum.
        /// </param>
        private void BonusChange(object e, decimal sum)
        {
            this.Bonus = this.Bonus + (int)sum / (int)this.AccountType;
        }
    }
}