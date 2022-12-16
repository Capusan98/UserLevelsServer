using Microsoft.EntityFrameworkCore;
namespace UserLevels
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //setup connection to dB
            services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(
               "SERVER=localhost\\MSSQLSERVER01;Database=UserLevels;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;",
                b => b.MigrationsAssembly(("UserLevels"))
            ));

            return services;
        }
    }
}
