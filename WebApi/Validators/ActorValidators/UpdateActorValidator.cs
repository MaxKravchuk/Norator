using Core.Entities;
using Core.ViewModels.ActorViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Validators.ActorValidators
{
    public class ActorValidator : AbstractValidator<ActorUpdateViewModel>
    {
        public ActorValidator()
        {
            RuleFor(vm => vm.Name)
                .MinimumLength(3)
                .WithMessage("Name length must be greater than 3")
                .MaximumLength(255)
                .WithMessage("Name length must be less than 255");

            RuleFor(vm => vm.DateOfBirth)
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
