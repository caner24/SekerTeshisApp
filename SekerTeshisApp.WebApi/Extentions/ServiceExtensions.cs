using FluentValidation.AspNetCore;
using MailKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using SekerTeshis.Core.CrossCuttingConcerns.MailService;
using SekerTeshis.Entity;
using SekerTeshisApp.Application;
using SekerTeshisApp.Application.Mail.Abstract;
using SekerTeshisApp.Application.Mail.Concrete;
using SekerTeshisApp.Data.Abstract;
using SekerTeshisApp.Data.Concrete;
using System.Reflection;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SekerTeshisApp.WebApi.MessageQueue.RabbitMQ;
using Microsoft.OpenApi.Models;

namespace SekerTeshisApp.WebApi.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SekerTeshisAppContext>(options =>
            options.UseSqlServer(
               config.GetConnectionString("sqlConnection"), sqlServerOptionsAction: sqlOptions =>
               {
                   sqlOptions.EnableRetryOnFailure(
                       maxRetryCount: 5,
                       maxRetryDelay: TimeSpan.FromSeconds(30),
                       errorNumbersToAdd: null);
               }));
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

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration config)
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

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserDal, UserDal>();

        }

        public static void ConfigureMailServices(this IServiceCollection services, IConfiguration config)
        {
            var emailConfig = config
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

            if (emailConfig != null)
                services.AddSingleton(emailConfig);

            services.AddSingleton<IMailSender, MailSender>();
        }

        public static void ConfigureRabbitMQ(this IServiceCollection services)
        {
            services.AddSingleton<MyMessageConsumer>();

        }
        public static void RabbitMQApp(this WebApplication app)
        {
            var messageConsumer = app.Services.GetService<MyMessageConsumer>();
            if (messageConsumer != null)
                messageConsumer.StartConsuming();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                   new OpenApiInfo
                   {
                       Title = "Seker Teshis Web Api",
                       Version = "v1",
                       Description = "SekerTeshis Web Api - Bitirme Proje A",
                       TermsOfService = new Uri("https://github.com/caner24/SekerTeshisApp"),
                       Contact = new OpenApiContact
                       {
                           Name = "Caner Ay Celep",
                           Email = "cnr24clp@gmail.com",
                           Url = new Uri("https://github.com/caner24")
                       }
                   });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Name = "Bearer"
                        },
                        new List<string>()
                    }
                });
            });
        }
    }

}
