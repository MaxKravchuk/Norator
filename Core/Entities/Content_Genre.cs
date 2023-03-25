using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Content_Genre
    {
        public int ContentId { get; set; }
        public Content Content { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
