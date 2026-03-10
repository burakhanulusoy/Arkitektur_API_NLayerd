using Arkitektur.Business.Services.AboutServices;
using Arkitektur.Business.Services.AppointmentService;
using Arkitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddServiceExt(this IServiceCollection services)
        {

            services.AddScoped<IAboutService,AboutService>();
            services.AddScoped<IAppointmnetService,AppointmentService>();


            //services.AddValidatorsFromAssembly(typeof(UpdateAppointmnetValidator).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            return services;
        }







    }
}
