using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.AutoMapper.Interfaces
{
    public interface IViewModelMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
