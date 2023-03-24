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
    public class GenreRepository : PagedRepository<Genre, GenreParameters>, IGenreRepository
    {
        public GenreRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            
        }
    }
}
