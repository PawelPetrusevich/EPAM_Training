// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" UserRegisterDtoValidator.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Common    
// </copyright>
// <summary>
//  Filename: UserRegisterDtoValidator.cs
//  Created day: 24.05.2018    16:51
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.Validators
{
    using Bank.Common.DTO;

    using FluentValidation;
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            this.RuleFor(x => x.Login).MinimumLength(3).WithMessage($"Min length 3 char");
            this.RuleFor(x => x.Email).EmailAddress().WithMessage($"Incorrect email");
            this.RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).MinimumLength(3).WithMessage($"Min length 3 char");
            this.RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage($"password not match");
        }
    }
}