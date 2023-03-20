using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.ActorViewModels
{
    public class ActorReadViewModel : ActorViewModel
    {
        public int Id { get; set; }
        public IEnumerable<ContentActorViewModel> contentViewModels { get; set; } = new List<ContentActorViewModel>();
    }
}
