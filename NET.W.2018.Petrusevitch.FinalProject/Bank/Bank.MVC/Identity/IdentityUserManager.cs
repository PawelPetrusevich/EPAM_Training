// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" IdentityUserManager.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.MVC    
// </copyright>
// <summary>
//  Filename: IdentityUserManager.cs
//  Created day: 24.05.2018    16:16
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.MVC.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;

    public class IdentityUserManager : UserManager<UserIdentity>
    {
        public IdentityUserManager(IUserStore<UserIdentity> store)
            : base(store)
        {
        }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options,IOwinContext context)
        {
            IdentityContext db = context.Get<IdentityContext>();
            IdentityUserManager manager = new IdentityUserManager(new UserStore<UserIdentity>(db));

            manager.PasswordValidator = new PasswordValidator { RequiredLength = 3, };

            return manager;
        }

    }
}