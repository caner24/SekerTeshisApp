using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SekerTeshis.Entity;
using SekerTeshisApp.Application;
using SekerTeshisApp.Data.Concrete;
using System.Reflection;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SekerTeshisApp.WebApi.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SekerTeshisAppContext>(options =>
            options.UseSqlServer(
               config.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 3;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<SekerTeshisAppContext>();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
             opt.TokenLifespan = TimeSpan.FromHours(2));

        }

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
        }

        public static void ConfigureJWT(this IServiceCollection services,IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }
    }
}
