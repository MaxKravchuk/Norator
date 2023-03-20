using FluentValidation.AspNetCore;
using WebApi.Validators;

namespace Norator.Configuration
{
    public static class SystemServicesConfiguration
    {
        public static void AddSystemServices(this IServiceCollection services)
        {
            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<ActorValidator>();
            });
        }
    }
}
