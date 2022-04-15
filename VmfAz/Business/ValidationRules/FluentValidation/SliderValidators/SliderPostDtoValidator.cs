using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.SliderValidators
{
    public class SliderPostDtoValidator : AbstractValidator<SliderPostDto>
    {
        public SliderPostDtoValidator()
        {
            RuleFor(x => x.Order).NotEmpty().WithMessage("Slider Order is required");
            RuleFor(x => x.RedirectURL).NotEmpty().WithMessage("Slider Redirect URL is required");
            RuleFor(x => x.File).NotEmpty().WithMessage("Slider Image is required");
            RuleFor(x => x.RedirectURL).MaximumLength(1000).WithMessage("Slider Redirect URL must be less than 1000 characters!");
            RuleFor(x => x.Order).LessThanOrEqualTo(0).WithMessage("Slider Order number must be greater than or equal to 1");
            RuleFor(x => x.Order).GreaterThanOrEqualTo(50).WithMessage("This number is too much for Slider Order number!");

        }
    }
}
