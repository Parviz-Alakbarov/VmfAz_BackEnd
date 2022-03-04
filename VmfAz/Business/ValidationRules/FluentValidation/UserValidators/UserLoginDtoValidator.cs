using Entities.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email length must be less than 100 character!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
        }
    }
}
