using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.UserViewModels
{
    public class UserReadViewModel : UserViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<ContentListReadViewModel> contentId { get; set; } = new List<ContentListReadViewModel>();
    }
}
