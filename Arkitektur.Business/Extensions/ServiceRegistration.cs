using Amazon.Runtime;
using Amazon.S3;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddServiceExt(this IServiceCollection services,IConfiguration configuration)
        {

            services.Scan(options => options.FromAssemblyOf<BusinessAssembly>()
                                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                                          .AsImplementedInterfaces()
                                          .WithScopedLifetime()


            );

            //services.AddValidatorsFromAssembly(typeof(UpdateAppointmnetValidator).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            //aws3 Ayralarý '''Warning'''

            var awsOptions = configuration.GetAWSOptions();


            awsOptions.Region = Amazon.RegionEndpoint.EUNorth1;
                
            awsOptions.Credentials = new BasicAWSCredentials(

                configuration["AWS:AccessKey"],
                configuration["AWS:SecretKey"]

            );

            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonS3>();


            return services;
        }







    }
}
