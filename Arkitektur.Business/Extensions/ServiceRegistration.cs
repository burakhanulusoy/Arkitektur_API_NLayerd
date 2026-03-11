using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddServiceExt(this IServiceCollection services)
        {

            services.Scan(options => options.FromAssemblyOf<BusinessAssembly>()
                                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                                          .AsImplementedInterfaces()
                                          .WithScopedLifetime()


            );





            //services.AddValidatorsFromAssembly(typeof(UpdateAppointmnetValidator).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            return services;
        }







    }
}
