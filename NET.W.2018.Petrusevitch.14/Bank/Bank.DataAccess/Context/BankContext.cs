// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" BankContext.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.DataAccess    
// </copyright>
// <summary>
//  Filename: BankContext.cs
//  Created day: 28.04.2018    17:31
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.DataAccess.Context
{
    using System.Data.Entity;

    using Bank.Common.Model;
    using Bank.DataAccess.Configurations;

    public class BankContext : DbContext
    {
        public BankContext() : base()
        {
        }
        
        public IDbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AccountConfiguration());
        }
    }
}