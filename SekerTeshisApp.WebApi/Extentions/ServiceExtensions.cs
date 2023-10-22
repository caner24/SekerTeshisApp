using Microsoft.EntityFrameworkCore;
using SekerTeshisApp.Data.Concrete;

namespace SekerTeshisApp.WebApi.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SekerTeshisAppContext>(_ => _.UseSqlServer(config.GetConnectionString("sqlConnection")));
        }

    }
}
