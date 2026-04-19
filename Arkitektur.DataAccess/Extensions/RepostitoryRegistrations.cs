using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Ýnterceptors;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
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


            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;

            }).AddEntityFrameworkStores<AppDbContext>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //hata aldým bunu koyunca geçti araþtýr anlamadým tam
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //auto registration
            services.Scan(options => options.FromAssemblyOf<DataAccessAssembly>()
                                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Repository")))
                                          .AsImplementedInterfaces()
                                          .WithScopedLifetime()
             );
                                    



            return services;


        }






    }
}
