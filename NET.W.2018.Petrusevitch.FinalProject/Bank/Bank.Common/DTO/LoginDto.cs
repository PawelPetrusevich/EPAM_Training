// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bank" file=" LoginDto.cs">
//  Creator name: 
//  Solution: Bank
//  Project: Bank.Common    
// </copyright>
// <summary>
//  Filename: LoginDto.cs
//  Created day: 24.05.2018    22:33
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Bank.Common.DTO
{
    using Bank.Common.Validators;

    using FluentValidation.Attributes;

    [Validator(typeof(LoginDtoValidator))]
    public class LoginDto
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}