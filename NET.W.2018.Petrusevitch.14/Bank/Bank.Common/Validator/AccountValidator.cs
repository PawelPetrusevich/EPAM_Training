// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" AccountValidator.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Common    
// </copyright>
// <summary>
//  Filename: AccountValidator.cs
//  Created day: 23.04.2018    20:43
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.Validator
{
    using Bank.Common.Model;

    using FluentValidation;
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.AccountType).NotNull();
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Balance).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Bonus).GreaterThanOrEqualTo(0);
        }
    }
}