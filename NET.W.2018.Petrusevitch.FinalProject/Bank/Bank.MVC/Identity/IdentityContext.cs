// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" IdentityContext.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.MVC    
// </copyright>
// <summary>
//  Filename: IdentityContext.cs
//  Created day: 24.05.2018    16:11
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.MVC.Identity
{
    using Microsoft.AspNet.Identity.EntityFramework;
    public class IdentityContext : IdentityDbContext<UserIdentity>
    {
        public IdentityContext() : base("IdentityDb")
        {
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}