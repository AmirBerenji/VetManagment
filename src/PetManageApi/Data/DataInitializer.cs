

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PetManageApi.Entities;

namespace PetManageApi.Data
{
    public class DataInitializer
    {
        public static async Task InitDbAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<PetManageDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedDataAsync(context, userManager, roleManager);
        }

        private static async Task SeedDataAsync(PetManageDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Apply pending migrations
            await context.Database.MigrateAsync();

            // Seed roles if they do not exist
            var roles = new[] { "Client", "PetShop", "Vet" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role, NormalizedName = role.ToUpper() });
                }
            }

            // Seed users if they do not exist
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "test@gmail.com",
                    UserName = "test@gmail.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "P@ssword123!");
                if (result.Succeeded)
                {


                    foreach (var role in roles)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }


                    var userInformation = new UserInformation()
                    {
                        FirstName = "Amir",
                        LastName = "Berenji",
                        PhoneNumber = "+37495802393",
                        Address = "Davtashen 1th 27/10",
                        UserId = user.Id,
                        RegisterTime = DateTime.UtcNow,
                        RegisterUserRef = user.Id,
                        IsDelete = false
                    };


                    context.UsersInfo.Add(userInformation);
                    context.SaveChanges();
                }
                else
                {
                    // Log or handle failure
                    Console.WriteLine($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }


    }
}
