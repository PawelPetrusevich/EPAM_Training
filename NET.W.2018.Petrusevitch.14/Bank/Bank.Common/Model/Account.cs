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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Bank.Common.Annotations;
    using Bank.Common.Enums;

    public class Account
    {
        private decimal balance;

        public Account()
        {
            this.BonusOnChange += this.BonusChange;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
                BonusChange(value);
            }
            
        }

        public int Bonus { get; set; }

        public AccountType AccountType { get; set; } = AccountType.Base;

        public bool IsDelete { get; set; } = false;

        public event EventHandler<decimal> BonusOnChange;

        private void BonusChange(decimal sum)
        {
            EventHandler<decimal> handler = BonusOnChange;
            if (handler != null)
            {
                handler(this, sum);
            }
        }

        private void BonusChange(object e, decimal sum)
        {
            this.Bonus = this.Bonus + (int)sum / (int)this.AccountType;
            Console.WriteLine("Event Call");
        }
    }
}