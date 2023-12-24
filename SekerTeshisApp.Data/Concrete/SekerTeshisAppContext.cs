using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SekerTeshis.Entity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Data.Concrete
{
    public class SekerTeshisAppContext : IdentityDbContext<User>
    {

        public SekerTeshisAppContext(DbContextOptions<SekerTeshisAppContext> context) : base(context)
        {

        }

        public SekerTeshisAppContext()
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Diabetes> Diabetes { get; set; }
        public DbSet<DiabetesDetail> DiabetesDetail { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<Food> Food { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:sekerteshisapp.database.windows.net,1433;Initial Catalog=sekerteshisapp;Persist Security Info=False;User ID=dbadmin;Password=45867-Sas;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                       sqlServerOptionsAction: sqlOptions =>
                       {

                           sqlOptions.EnableRetryOnFailure(
                               maxRetryCount: 5,
                               maxRetryDelay: TimeSpan.FromSeconds(30),
                               errorNumbersToAdd: null);
                       });
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
