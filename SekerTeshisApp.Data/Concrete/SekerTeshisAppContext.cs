using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SekerTeshis.Entity;
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

        public DbSet<Diabetes> Diabetes { get; set; }
        public DbSet<DiabetesDetail> DiabetesDetail { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"SERVER=CANER;INITIAL CATALOG=SekerTeshisApp;INTEGRATED SECURITY=True;Encrypt=True;TrustServerCertificate=True");
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
