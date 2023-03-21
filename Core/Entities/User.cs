using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public ICollection<User_Content> User_Contents { get; set; }
    }
}
