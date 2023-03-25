using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Paginator.Parameters;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : PagedRepository<User, UserParameters>, IUserRepository
    {
        public UserRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            
        }
    }
}
