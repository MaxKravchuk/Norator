using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.ActorViewModels
{
    public class ActorUpdateViewModel : ActorViewModel
    {
        public int Id { get; set; }
        public IEnumerable<int> ContentIds { get; set; } = new List<int>();
    }
}
