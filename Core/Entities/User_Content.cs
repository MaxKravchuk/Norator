using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User_Content
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ContentId { get; set; }
        public Content? Content { get; set; }
    }
}
