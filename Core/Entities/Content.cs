using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfSubscribers { get; set; } = 0;
        public int ContentCategoryId { get; set; }
        public ContentCategory ContentCategory { get; set; }
        public ICollection<Content_Genre> Content_Genres { get; set; }
        public ICollection<Content_Actor> Content_Actors { get; set; }
        public ICollection<User_Content> User_Contents { get; set; }
    }
}
