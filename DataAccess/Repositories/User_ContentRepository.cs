using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class User_ContentRepository : Repository<User_Content>, IUser_ContentRepository
    {
        private readonly NoratorContext _noratorContext;
        public User_ContentRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            _noratorContext = noratorContext;
        }

        public async Task<User_Content> GetUserContentByUserAndContentId(int userId, int contentId)
        {
            var userContent = await _noratorContext.UserContents.Where(x =>
                (x.UserId == userId && x.ContentId == contentId)).SingleOrDefaultAsync();
            
            return userContent;
        }
    }
}
