using Entities.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
    public class UserForRefreshTokenDtoValidator : AbstractValidator<UserForRefreshTokenDto>
    {
        public UserForRefreshTokenDtoValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Token is required!");
        }
    }
}
