using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.ContentViewModels
{
    public class ContentViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ContentType { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfSubscribers { get; set; }
    }
}
