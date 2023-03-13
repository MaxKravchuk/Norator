using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Content_Actor> Content_Actors { get; set; }
    }
}
