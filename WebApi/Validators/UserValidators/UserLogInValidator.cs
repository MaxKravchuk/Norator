using Core.ViewModels.UserViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Validators.UserValidators
{
    public class UserLogInValidator : AbstractValidator<UserLogInViewModel>
    {
        public UserLogInValidator()
        {
            RuleFor(x => x.NickName)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
