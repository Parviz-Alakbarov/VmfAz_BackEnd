using Entities.DTOs.BrandDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.BrandValidators
{
    public class BrandPostDtoValidator : AbstractValidator<BrandPostDto>
    {
        public BrandPostDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Brand name is Required!");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("Brnad Name must be less than 50 character!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Brand Description is Required!");
            RuleFor(x => x.Description).MaximumLength(2000).WithMessage("Brnad Description must be less than 2000 character!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Brand Image is Required!");
            RuleFor(x => x.PosterImage).NotEmpty().WithMessage("Brand Poster Image is Required!");

        }
    }
}
