using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class User_ContentRepository : Repository<User_Content>, IUser_ContentRepository
    {
        public User_ContentRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            
        }
    }
}
