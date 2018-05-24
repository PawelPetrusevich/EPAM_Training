// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" UserRegisterDto.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Common    
// </copyright>
// <summary>
//  Filename: UserRegisterDto.cs
//  Created day: 24.05.2018    16:51
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.DTO
{
    using Bank.Common.Validators;

    using FluentValidation.Attributes;

    [Validator(typeof(UserRegisterDtoValidator))]
    public class UserRegisterDto
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}