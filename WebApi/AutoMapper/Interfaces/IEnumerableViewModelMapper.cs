using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.AutoMapper.Interfaces
{
    public interface IEnumerableViewModelMapper<TSource, TViewModel> : IViewModelMapper<TSource, TViewModel>
    {
        public IEnumerable<TViewModel> Map(IEnumerable<TSource> source)
        {
            return source.Select<TSource, TViewModel>(item => Map(item));
        }
    }
}
