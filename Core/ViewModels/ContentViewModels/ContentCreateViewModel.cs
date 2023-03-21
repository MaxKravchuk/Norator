using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.ContentViewModels
{
    public class ContentCreateViewModel : ContentViewModel
    {
        public IEnumerable<int> Genres { get; set; } = new List<int>();
    }
}
