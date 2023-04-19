using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.UserViewModels
{
    public class UserCreateViewModel : UserViewModel
    {
        public DateTime? DateOfBirth { get; set; }
        public string? Password { get; set; }
    }
}
