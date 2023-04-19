using Core.ViewModels.GenreViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Validators.GenreValidators
{
    public class CreateGenreValidator : AbstractValidator<GenreCreateViewModel>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
