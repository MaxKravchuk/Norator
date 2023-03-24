using Core.Entities;
using Core.Paginator;
using Core.ViewModels;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.ContentViewModels;
using Core.ViewModels.GenreViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.ActorAutoMappers;
using WebApi.AutoMapper.ActorAutoMappers.Helpers;
using WebApi.AutoMapper.ContentAutoMappers;
using WebApi.AutoMapper.ContentAutoMappers.Helpers;
using WebApi.AutoMapper.GenreAutoMappers;
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

            services.AddScoped<IViewModelMapper<ContentCreateViewModel, Content>, ContentCreateMapper>();
            services.AddScoped<IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>>, ContentListReadMapper>();
            services.AddScoped<IViewModelMapper<Content, ContentReadViewModel>, ContentReadMapper>();
            services.AddScoped<IViewModelMapper<ContentUpdateViewModel, Content>, ContentUpdateMapper>();
            services.AddScoped<IViewModelMapper<PagedList<Content>, PagedReadViewModel<ContentListReadViewModel>>, ContentPagedMapper>();
            services.AddScoped<IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentPropsViewModel>>, ContentActorMapper>();
            services.AddScoped<IEnumerableViewModelMapper<IEnumerable<Content_Genre>, IEnumerable<ContentPropsViewModel>>, ContentGenreMapper>();

            services.AddScoped<IViewModelMapper<GenreCreateViewModel, Genre>, GenreCreateMapper>();
            services.AddScoped<IEnumerableViewModelMapper<IEnumerable<Genre>, IEnumerable<GenreUpdateViewModel>>, GenreListReadMapper>();
            services.AddScoped<IViewModelMapper<PagedList<Genre>, PagedReadViewModel<GenreUpdateViewModel>>, GenrePagedMapper>();
            services.AddScoped<IViewModelMapper<GenreUpdateViewModel, Genre>, GenreReadMapper>();
        }
    }
}
