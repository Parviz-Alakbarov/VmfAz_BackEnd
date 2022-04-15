using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShopValidators
{
    public class ShopPostDtoValidator : AbstractValidator<ShopPostDto>
    {
        public ShopPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Shop Name is required!");
            RuleFor(x => x.RedirectUrl).NotEmpty().WithMessage("Shop RedirectUrl is required!");
            RuleFor(x => x.PhoneNumber1).NotEmpty().WithMessage("The Shop must have at least one number");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Shop Email is required!");
            RuleFor(x => x.Longitude).NotEmpty().WithMessage("Shop Longitude is required!");
            RuleFor(x => x.Latitude).NotEmpty().WithMessage("Shop Latitude is required!");
            RuleFor(x => x.OpenHour).NotEmpty().WithMessage("Shop Open Hour is required!");
            RuleFor(x => x.CloseHour).NotEmpty().WithMessage("Shop Close Hour is required!");
            RuleFor(x => x.OpenMinute).NotEmpty().WithMessage("Shop Open Minute is required!");
            RuleFor(x => x.CloseMinute).NotEmpty().WithMessage("Shop Close Minute is required!");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Shop Address Minute is required!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Shop Name must be less than 50 character!");
            RuleFor(x => x.Address).MaximumLength(500).WithMessage("Shop Address must be less than 500 character!");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Shop Emiail must be less than 500 character!");
            RuleFor(x => x.RedirectUrl).MaximumLength(100).WithMessage("Shop RedirectUrl must be less than 500 character!");
            RuleFor(x => x.PhoneNumber1).MaximumLength(15).WithMessage("Phone number must be less than 15 character!");
            RuleFor(x => x.PhoneNumber2).MaximumLength(15).WithMessage("Phone number must be less than 15 character!");

            RuleFor(x => x.OpenHour).Must(x => x < 24 && x >= 0)
                .WithMessage("Invalid Hour Input for Opening time");
            RuleFor(x => x.CloseHour).Must(x => x < 24 && x >= 0)
                .WithMessage("Invalid Hour Input for Closing time");

            RuleFor(x => x.CloseMinute).Must(x => x < 60 && x >= 0)
                    .WithMessage("Invalid Minute Input for Closing time");
            RuleFor(x => x.OpenMinute).Must(x => x < 60 && x >= 0)
                .WithMessage("Invalid Minute Input for Opening time");
        }
    }
}
