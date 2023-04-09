using Application.Services;
using Core.Interfaces.Services;
using FluentValidation.AspNetCore;
using WebApi.Validators;

namespace Norator.Configuration
{
    public static class SystemServicesConfiguration
    {
        public static void AddSystemServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<ActorValidator>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "Norator",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  });
            });
        }
    }
}
