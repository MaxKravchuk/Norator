using Core.Entities;
using Core.Paginator;
using Core.ViewModels;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.ContentViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.ActorAutoMappers;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper
{
    public static class ApplicationMappersConfiguration
    {
        public static void AddApplicationMappers(this IServiceCollection services)
        {
            services.AddScoped<IViewModelMapper<ActorCreateViewModel, Actor>, ActorCreateMapper>();
            services.AddScoped<IEnumerableViewModelMapper<IEnumerable<Actor>, IEnumerable<ActorListReadViewModel>>, ActorListReadMapper>();
            services.AddScoped<IViewModelMapper<Actor, ActorReadViewModel>, ActorReadMapper>();
            services.AddScoped<IViewModelMapper<ActorUpdateViewModel, Actor>, ActorUpdateMapper>();
            services.AddScoped<IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentActorViewModel>>, ActorContentMapper>();
            services.AddScoped<IViewModelMapper<PagedList<Actor>, PagedReadViewModel<ActorListReadViewModel>>, ActorPagedMapper>();
        }
    }
}
