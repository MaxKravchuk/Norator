﻿using Core.ViewModels.ActorViewModels;
using Core.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.ContentViewModels
{
    public class ContentUpdateViewModel : ContentViewModel
    {
        public int Id { get; set; }
        public int ContentCategoryId { get; set; }
        public IEnumerable<int> actorsId { get; set; } = new List<int>();
        public IEnumerable<int> genresId { get; set; } = new List<int>();

    }
}
