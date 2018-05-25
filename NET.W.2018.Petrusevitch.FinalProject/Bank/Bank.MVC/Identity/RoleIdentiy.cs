// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" RoleIdentiy.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.MVC    
// </copyright>
// <summary>
//  Filename: RoleIdentiy.cs
//  Created day: 25.05.2018    11:47
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.MVC.Identity
{
    using Microsoft.AspNet.Identity.EntityFramework;
    public class RoleIdentiy : IdentityRole
    {
        public string Description { get; set; }
        
    }
}