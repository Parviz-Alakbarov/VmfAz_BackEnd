using Entities.DTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender is required!");
            RuleFor(x => x.GenderId).GreaterThan(0).WithMessage("GenderId can't be less than 0!");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Brand is required!");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage("BranddId can't be less than 0!");
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("Sale Price is required!");
            RuleFor(x => x.CostPrice).NotEmpty().WithMessage("Cost Price is required!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Description must be less than 1000 character!");
        }
    }
}
