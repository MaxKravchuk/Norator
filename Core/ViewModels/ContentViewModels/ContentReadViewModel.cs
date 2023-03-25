using Core.ViewModels.ActorViewModels;
using Core.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.ContentViewModels
{
    public class ContentReadViewModel : ContentViewModel
    {
        public int Id { get; set; }
        public string ContentCategory { get; set; }
        public IEnumerable<ContentPropsViewModel> actorsViewModels { get; set; } = new List<ContentPropsViewModel>();
        public IEnumerable<ContentPropsViewModel> genreViewModels { get; set; } = new List<ContentPropsViewModel>();

    }
}
