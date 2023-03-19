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
        public IEnumerable<ContentViewModel> contentViewModels { get; set; } = new List<ContentViewModel>();
    }
}
