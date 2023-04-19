using Core.Entities;
using Core.Paginator.Parameters;
using Core.Paginator;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<ContentCategory>
    {
    }
}
