using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
    }
}
