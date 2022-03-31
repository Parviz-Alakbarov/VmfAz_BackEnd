﻿using Entities.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
    public class UserChangePasswordDtoValidator : AbstractValidator<UserChangePasswordDto>
    {
        public UserChangePasswordDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email must be less than 100 character!");


            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("CurrentPassword is required!");
            RuleFor(x => x.CurrentPassword).MinimumLength(6).WithMessage("CurrentPassword mustbe more than 6 character!");
            RuleFor(x => x.CurrentPassword).MaximumLength(25).WithMessage("Invalid CurrentPassword Length");
            RuleFor(x => x.CurrentPassword).Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,25}$").WithMessage("Password didn't match requirements!");


            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("NewPassword is required!");
            RuleFor(x => x.NewPassword).MinimumLength(6).WithMessage("NewPassword mustbe more than 6 character!");
            RuleFor(x => x.NewPassword).MaximumLength(25).WithMessage("Invalid NewPassword Length");
            RuleFor(x => x.NewPassword).Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,25}$").WithMessage("NewPassword didn't match requirements!");
        }
    }
}
