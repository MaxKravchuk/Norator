using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.ActorViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.ActorAutoMappers;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IViewModelMapper<ActorCreateViewModel, Actor> _actorCreateVM;
        private readonly IViewModelMapper<ActorUpdateViewModel, Actor> _actorUpdateVM;
        private readonly IViewModelMapper<Actor, ActorReadViewModel> _actorVMMapper;
        private readonly IEnumerableViewModelMapper<IEnumerable<Actor>, IEnumerable<ActorReadViewModel>> _readListMapper;

        public ActorController(
            IActorService actorService,
            IViewModelMapper<ActorCreateViewModel, Actor> actorCreateVM,
            IViewModelMapper<ActorUpdateViewModel, Actor> actorUpdateVM,
            IViewModelMapper<Actor, ActorReadViewModel> actorVMMapper,
            IEnumerableViewModelMapper<IEnumerable<Actor>, IEnumerable<ActorReadViewModel>> readListMapper
            )
        {
            _actorCreateVM = actorCreateVM;
            _actorUpdateVM = actorUpdateVM; 
            _readListMapper = readListMapper;
            _actorVMMapper = actorVMMapper;
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorReadViewModel>> GetAsync()
        {
            var actors = await _actorService.GetActorsAsync();
            var viewModels = _readListMapper.Map(actors);
            return viewModels;
        }
    }
}
