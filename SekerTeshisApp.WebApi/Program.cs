using Microsoft.AspNetCore.Identity;
using SekerTeshis.Entity;
using SekerTeshisApp.WebApi.Extentions;
using AutoMapper;
using System.Reflection;
using FluentValidation.AspNetCore;
using SekerTeshisApp.Application.ActionFilters;
using Serilog;
using SekerTeshisApp.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


builder.Services.AddControllers(config => config.Filters.Add(new ValidationFilterAttribute()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureSqlServer(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("SekerTeshisApp.Application")));
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureServices();
builder.Services.ConfigureMailServices(builder.Configuration);
builder.Services.ConfigureRabbitMQ();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{

}
else
{
    app.UseHsts();
}
app.UseCors("CorsPolicy");
app.RabbitMQApp();
app.UseHttpsRedirection();
app.ConfigureExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var configuration = services.GetRequiredService<IConfiguration>();
    await SeedIdentity.CreateIdentityUsers(services, configuration);
}
app.Run();
