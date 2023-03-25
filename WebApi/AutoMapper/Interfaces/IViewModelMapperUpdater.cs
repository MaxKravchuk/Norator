using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.AutoMapper.Interfaces
{
    public interface IViewModelMapperUpdater<TSource, TDestination> : IViewModelMapper<TSource, TDestination>
    {
        void Map(TSource source, TDestination dest);
    }
}
