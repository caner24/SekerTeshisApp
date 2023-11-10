using Microsoft.AspNetCore.Identity;
using SekerTeshis.Entity;

namespace SekerTeshisApp.WebApi.Extentions
{
    public static class SeedIdentity
    {
        public static async Task CreateIdentityUsers(this IServiceProvider services, IConfiguration configuration)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                User user = new User()
                {
                    UserName = username,
                    Email = email,
                };

                IdentityResult result = await userManager.CreateAsync(user, password);
                var userMail = await userManager.FindByEmailAsync(user.Email);
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                await userManager.ConfirmEmailAsync(userMail, token);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
