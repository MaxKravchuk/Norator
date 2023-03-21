using Core.Entities;
using Core.ViewModels.ActorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ActorAutoMappers
{
    public class ActorListToListMapper : IEnumerableViewModelMapper<IEnumerable<Actor>, IEnumerable<ActorReadViewModel>>
    {
        private readonly IViewModelMapper<Actor, ActorReadViewModel> _readMapper;

        public ActorListToListMapper(IViewModelMapper<Actor, ActorReadViewModel> viewModelMapper)
        {
            _readMapper = viewModelMapper;
        }

        public IEnumerable<ActorReadViewModel> Map(IEnumerable<Actor> source)
        {
            var readViewModels = source.Select(actor => _readMapper.Map(actor));
            return readViewModels;
        }
    }
}
