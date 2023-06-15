using Core.Enums;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var arinmisUser = new ApplicationUser
            {
                UserName = "arinmis",
                Email = "mustafa_arinmis@outlook.com",
                FirstName = "mustafa",
                LastName = "arinmis",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != arinmisUser.Id))
            {
                var user = await userManager.FindByEmailAsync(arinmisUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(arinmisUser, "Arinmis123.");
                    await userManager.AddToRoleAsync(arinmisUser, Roles.Basic.ToString());
                }

            }



            var yusufUser = new ApplicationUser
            {
                UserName = "selamYusufBen",
                Email = "yusuf@gmail.com",
                FirstName = "yusuf",
                LastName = "tanrikulu",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != yusufUser.Id))
            {
                var user = await userManager.FindByEmailAsync(yusufUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(yusufUser, "Yusuf123.");
                    await userManager.AddToRoleAsync(yusufUser, Roles.Basic.ToString());
                }

            }


            var testUser = new ApplicationUser
            {
                UserName = "testtest",
                Email = "test@test.com",
                FirstName = "test",
                LastName = "test",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != testUser.Id))
            {
                var user = await userManager.FindByEmailAsync(testUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(testUser, "Testtest1.");
                    await userManager.AddToRoleAsync(testUser, Roles.Basic.ToString());
                }

            }


        }
    }
}
