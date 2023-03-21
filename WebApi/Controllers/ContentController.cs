using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.ContentViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContenService _contenService;
        private readonly IViewModelMapper<ContentCreateViewModel, Content> _createMapper;
        private readonly IViewModelMapper<ContentUpdateViewModel, Content> _updateMapper;
        private readonly IViewModelMapper<Content, ContentReadViewModel> _readMapper;
        private readonly IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>> _listReadMapper;

        public ContentController(
            IContenService contenService,
            IViewModelMapper<ContentCreateViewModel, Content> createMapper,
            IViewModelMapper<ContentUpdateViewModel, Content> updateMapper,
            IViewModelMapper<Content, ContentReadViewModel> readMapper,
            IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>> listReadMapper
            )
        {
            _contenService = contenService;
            _createMapper = createMapper;
            _updateMapper = updateMapper;
            _readMapper = readMapper;
            _listReadMapper = listReadMapper;
        }
    }
}
