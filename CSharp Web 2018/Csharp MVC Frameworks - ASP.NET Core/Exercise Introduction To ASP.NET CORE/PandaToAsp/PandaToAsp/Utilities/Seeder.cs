namespace PandaToAsp.Utilities
{
    using Microsoft.AspNetCore.Identity;
    using Panda.Models;
    using PandaToAsp.Data;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Seeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> _roleManager)
        {
            bool AdminRoleExists = await _roleManager.RoleExistsAsync("Admin");
            if (!AdminRoleExists)
            {
                var adminRole = new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "0" };
                var result = await _roleManager.CreateAsync(adminRole);
            }

            bool UserRoleExists = await _roleManager.RoleExistsAsync("User");
            if (!UserRoleExists)
            {
                var userRole = new IdentityRole() { Name = "User", NormalizedName = "USER", ConcurrencyStamp = "1" };
                var result = await _roleManager.CreateAsync(userRole);
            }
        }
    }
}