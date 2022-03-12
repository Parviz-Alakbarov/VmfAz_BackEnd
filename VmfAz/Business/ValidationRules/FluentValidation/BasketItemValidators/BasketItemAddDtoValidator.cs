using Entities.DTOs.OrderDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.BasketItemValidators
{
    public class BasketItemAddDtoValidator : AbstractValidator<BasketItemAddDto>
    {
        public BasketItemAddDtoValidator()
        {
            RuleFor(x=>x.ProductId).NotEmpty().WithMessage("Product Is required!");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greather than 0!");
            RuleFor(x => x.AppUserId).NotEmpty().WithMessage("User Is required!");
            RuleFor(x => x.AppUserId).GreaterThan(0).WithMessage("UserId must be greather than 0!");
            RuleFor(x => x.Count).NotEmpty().WithMessage("Count Is required!");
            RuleFor(x => x.Count).GreaterThan(0).WithMessage("Count must be greather than 0!");
        }
    }
}
