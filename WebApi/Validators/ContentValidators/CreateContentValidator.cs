using Core.ViewModels.ContentViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Validators.ContentValidators
{
    public class CreateContentValidator : AbstractValidator<ContentCreateViewModel>
    {
        public CreateContentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ReleaseDate)
                .NotEmpty();

            RuleFor(x => x.ContentCategoryId)
                .NotEmpty();

            RuleFor(x => x.Actors)
                .Must(x => x.Count() <= 10)
                .WithMessage("Maximus 10 actors per content");
        }
    }
}
