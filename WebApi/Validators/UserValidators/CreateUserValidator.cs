using Core.ViewModels.UserViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Validators.UserValidators
{
    public class CreateUserValidator : AbstractValidator<UserCreateViewModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.NickName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(50);

            RuleFor(x => x.DateOfBirth)
                .Must(BeBornNotInThisYear)
                .WithMessage("You must be older 18");
        }

        private bool BeBornNotInThisYear(DateTime? date)
        {
            if (DateTime.Now.Year == date.Value.Year)
            {
                return false;
            }

            return true;
        }
    }
}
