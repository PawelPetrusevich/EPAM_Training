// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" NinjectConfiguration.cs">
//  Creator name: 
//  Solution: Bank
//  Project: BankConsole    
// </copyright>
// <summary>
//  Filename: NinjectConfiguration.cs
//  Created day: 23.04.2018    20:21
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace BankConsole
{
    using System.Data.Entity;

    using Bank.BusinessLogic;
    using Bank.Common.Interface;
    using Bank.DataAccess;
    using Bank.DataAccess.Context;

    using Ninject.Modules;

    public class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBankService>().To<BankService>();
            this.Bind<IBankRepository>().To<BankRepository>();
            this.Bind<DbContext>().To<BankContext>();
        }
    }
}