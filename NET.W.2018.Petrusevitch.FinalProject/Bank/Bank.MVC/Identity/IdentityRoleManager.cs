// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" IdentityRoleManager.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.MVC    
// </copyright>
// <summary>
//  Filename: IdentityRoleManager.cs
//  Created day: 25.05.2018    11:48
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.MVC.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;

    public class IdentityRoleManager : RoleManager<RoleIdentiy>
    {
        public IdentityRoleManager(IRoleStore<RoleIdentiy, string> store)
            : base(store)
        {
        }

        public static IdentityRoleManager Create(
            IdentityFactoryOptions<IdentityRoleManager> options,
            IOwinContext context)
        {
            return new IdentityRoleManager(new RoleStore<RoleIdentiy>(context.Get<IdentityContext>()));
        }
    }
}