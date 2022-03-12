using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SettingPostDtoValidator : AbstractValidator<SettingPostDto>
    {
        public SettingPostDtoValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required!");
            RuleFor(x => x.Key).MaximumLength(100).WithMessage("Key can't be more than 100 character");
            RuleFor(x => x.Value).MaximumLength(1000).When(x=>!string.IsNullOrEmpty(x.Value)).WithMessage("Key can't be more than 100 character");
        }
    }

}
