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
        public IEnumerable<ActorViewModel> contentViewModels { get; set; } = new List<ActorViewModel>();
        public IEnumerable<GenreViewModel> genreViewModels { get; set; } = new List<GenreViewModel>();

    }
}
