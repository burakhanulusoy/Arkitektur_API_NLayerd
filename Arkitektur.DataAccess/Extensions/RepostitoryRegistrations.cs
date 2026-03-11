using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Ýnterceptors;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkitektur.DataAccess.Extensions
{
    public static class RepostitoryRegistrations
    {


        public static IServiceCollection AddRepositoriesExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));

                options.AddInterceptors(new AuditDbContextInterceptors());

            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.Scan(options => options.FromAssemblyOf<DataAccessAssembly>()
                                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Repository")))
                                          .AsImplementedInterfaces()
                                          .WithScopedLifetime()
             );
                                    



            return services;


        }






    }
}
