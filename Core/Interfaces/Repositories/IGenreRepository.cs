using Core.Entities;
using Core.Paginator.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IGenreRepository : IRepository<Genre>, IPagedRepository<Genre, GenreParameters>
    {

    }
}
