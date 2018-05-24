// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" LoginDtoValidator.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Common    
// </copyright>
// <summary>
//  Filename: LoginDtoValidator.cs
//  Created day: 24.05.2018    22:34
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.Validators
{
    using Bank.Common.DTO;

    using FluentValidation;
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            this.RuleFor(x => x.Login).NotEmpty().WithMessage($"Enter login");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage($"Enter password");
        }
    }
}