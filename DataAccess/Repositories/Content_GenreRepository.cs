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
    public class Content_GenreRepository : Repository<Content_Genre>, IContent_GenreRepository
    {
        public Content_GenreRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            
        }
    }
}
