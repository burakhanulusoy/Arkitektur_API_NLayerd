using Arkitektur.Business.Services.AboutServices;
using Microsoft.Extensions.DependencyInjection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddServiceExt(this IServiceCollection services)
        {

            services.AddScoped<IAboutService,AboutService>();





            return services;
        }







    }
}
