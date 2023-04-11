using Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Configuration
{
    public static class ApplicationRepositoriesConfiguration
    {
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IContent_ActorRepository, Content_ActorRepository>();
            services.AddScoped<IContent_GenreRepository, Content_GenreRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUser_ContentRepository,  User_ContentRepository>();
            services.AddScoped<IContentCategoryRepository, ContentCategoryRepository>();
        }
    }
}
