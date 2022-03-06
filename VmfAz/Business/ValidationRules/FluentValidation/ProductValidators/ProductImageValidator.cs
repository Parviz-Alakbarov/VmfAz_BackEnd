using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductImageValidator : AbstractValidator<ProductImage>
    {
        public ProductImageValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required!");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Product id can't be less than 0!");
        }
    }
}
