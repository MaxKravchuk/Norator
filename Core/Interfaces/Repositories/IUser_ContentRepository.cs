using Core.Entities;
using Core.Paginator.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUser_ContentRepository : IRepository<User_Content>
    {
        Task<User_Content> GetUserContentByUserAndContentId(int userId, int contentId);
    }
}
