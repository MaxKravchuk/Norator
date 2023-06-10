using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.ContentViewModels
{
    public class ContentListReadViewModel : ContentViewModel
    {
        public int Id { get; set; }
        public string? ContentCategory { get; set; }
        public int NumberOfSubscribers { get; set; }
    }
}
