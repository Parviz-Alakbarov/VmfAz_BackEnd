using Entities.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.FirstName).MaximumLength(25).WithMessage("FirstName must be less than 50 character!");

            RuleFor(x => x.LastName).MaximumLength(25).WithMessage("LastName must be less than 50 character!");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required!");
            RuleFor(x => x.PhoneNumber).MaximumLength(15).WithMessage("PhoneNumber must be less than 15 character!");

            RuleFor(x => x.CountryId).NotEmpty().WithMessage("Country is required!");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("City is required!");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required!");
            RuleFor(x => x.Address).MaximumLength(500).WithMessage("Address must be less than 500 character!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email must be less than 100 character!");
        }
    }
}
