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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name is required!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Product Name must be less than 100 character!");
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("Sale Price is required!");
            RuleFor(x => x.CostPrice).NotEmpty().WithMessage("Cost Price is required!");
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(0).WithMessage("Sale Price can't be less than 0!");
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0).WithMessage("Cost Price can't be less than 0!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Description must be less than 1000 character!");
            RuleFor(x => x.DiscountPercent).GreaterThanOrEqualTo(0).WithMessage("Discont price can't be less than 0!");
            RuleFor(x => x.DiscountPercent).LessThanOrEqualTo(100).WithMessage("Invalid Discount Percent!");
            RuleFor(x => x).Custom((x, content) =>
            {
                if (x.CostPrice > x.SalePrice)
                {
                    content.AddFailure("CostPrice", "CostPrice can't be less than SalePrice");
                }
            });
        }
    }
}
