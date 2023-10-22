using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SekerTeshisApp.Data.Concrete;

namespace SekerTeshisApp.WebApi.DesignTime
{
    public class SekerTeshisAppDesignTimeContext : IDesignTimeDbContextFactory<SekerTeshisAppContext>
    {
        public SekerTeshisAppContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();


            var builder = new DbContextOptionsBuilder<SekerTeshisAppContext>();
            var connectionStrings = config.GetConnectionString("sqlConnection");
            builder.UseSqlServer(connectionStrings);
            return new SekerTeshisAppContext(builder.Options);
        }
    }
}
