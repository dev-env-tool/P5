using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace P3AddNewFunctionalityDotNetCore.Data
{
    public static class IdentitySeedData
    {
        private const string AdminEmail = "Admin200@gmail.com";
        private const string AdminPassword = "P@ssword12345";

        public static async Task EnsurePopulated(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var userManager = (UserManager<IdentityUser>)scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>));

            IdentityUser user = await userManager.FindByIdAsync(AdminEmail);

            if (user == null)
            {
                user = new IdentityUser();
                user.UserName = AdminEmail;
                user.Email = AdminEmail;
                user.EmailConfirmed = true;
                await userManager.CreateAsync(user, AdminPassword);
            }



            using var scopetest = app.Services.CreateScope();
            var userManagertest = scopetest.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var usertest = await userManager.FindByNameAsync("Admin100");
            if (user != null)
            {
                bool validPassword = await userManager.CheckPasswordAsync(user, "P@ssword1234");
                Console.WriteLine($"Mot de passe correct ? {validPassword}");
            }
            else
            {
                Console.WriteLine("Utilisateur Admin non trouvé.");
            }

        }
    }
}



