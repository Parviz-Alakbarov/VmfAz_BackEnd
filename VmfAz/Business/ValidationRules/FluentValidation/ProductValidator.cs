using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name is required!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Product Name must be more than 2 characters!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Product Name must be less than 100 characters!");
            RuleFor(x => x.CostPrice).NotEmpty().WithMessage("CostPrice is required");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("BrandId is required!");
        }
    }
}
