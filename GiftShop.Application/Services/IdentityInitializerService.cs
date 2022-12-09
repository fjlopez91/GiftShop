using GiftShop.Application.Constants;
using GiftShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace GiftShop.Application.Services
{
    public sealed class IdentityInitializerService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public static readonly Guid DefaultAdminGuid = Guid.NewGuid();
        public Guid? AdminId { get; set; }
        public Guid? ClientId { get; set; }
        public string TestClientEmail { get; set; } = default!;

        public IdentityInitializerService(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Run(string adminEmail)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new Role { Name = UserRoles.Admin });
                }

                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _roleManager.CreateAsync(new Role { Name = UserRoles.User });
                }

                // Create initial admin user
                if (await _userManager.FindByEmailAsync(adminEmail) == null)
                {
                    await CreateIfNotExists(AdminId, adminEmail, "System", "Admin", UserRoles.Admin);
                }

                if (TestClientEmail != null)
                {
                    await CreateIfNotExists(ClientId, TestClientEmail, "Client", "User", UserRoles.User);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Identity database could not be initialized.", ex);
            }
        }

        private async Task CreateIfNotExists(Guid? id, string email, string fistName, string lastName, string role)
        {
            var user = new User
            {
                Id = id.GetValueOrDefault(Guid.NewGuid()),
                UserName = "admin",
                Email = email,
                EmailConfirmed = true,
                FirstName = fistName,
                LastName = lastName,
                DateCreated = DateTime.UtcNow,
                PhoneNumber = "999999999",
                Status = Domain.Enums.EnabledStatus.Enabled
            };

            var identityResult = await _userManager.CreateAsync(user, "P@ssw0rd");
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }
    }
}