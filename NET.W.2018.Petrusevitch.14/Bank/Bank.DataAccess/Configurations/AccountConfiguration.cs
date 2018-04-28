// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" AccountConfiguration.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.DataAccess    
// </copyright>
// <summary>
//  Filename: AccountConfiguration.cs
//  Created day: 28.04.2018    17:40
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.DataAccess.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Bank.Common.Model;
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Balance).IsRequired();
            this.Property(x => x.AccountType).IsRequired();
            this.Property(x => x.Bonus).IsRequired();
            this.Property(x => x.FirstName).IsRequired();
            this.Property(x => x.IsDelete).IsRequired();
            this.Property(x => x.LastName).IsRequired();
        }
    }
}