using Entities.DTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("Sale Price is required!");
            RuleFor(x => x.CostPrice).NotEmpty().WithMessage("Cost Price is required!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Description must be less than 1000 character!");
            RuleFor(x => x.DiscountPercent).GreaterThanOrEqualTo(0).WithMessage("Discont price can't be less than 0!");
        }
    }
}
