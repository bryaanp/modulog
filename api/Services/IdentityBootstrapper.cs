using Microsoft.AspNetCore.Identity;
using Modulog.Api.Domain;

namespace Modulog.Api.Services;

public static class IdentityBootstrapper
{
    private const string AdminRole = "admin";

    public static async Task ApplyAsync(IServiceProvider services, IConfiguration configuration)
    {
        await using var scope = services.CreateAsyncScope();
        var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        var users = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        if (!await roles.RoleExistsAsync(AdminRole))
        {
            var roleResult = await roles.CreateAsync(new IdentityRole<Guid>(AdminRole));
            EnsureSucceeded(roleResult, "create the admin role");
        }

        var adminEmail = configuration["BootstrapAdmin:Email"];
        if (string.IsNullOrWhiteSpace(adminEmail))
        {
            return;
        }

        var user = await users.FindByEmailAsync(adminEmail.Trim());
        if (user is null)
        {
            throw new InvalidOperationException(
                "BootstrapAdmin:Email does not match a registered user. Register the user, then restart the API.");
        }

        if (!await users.IsInRoleAsync(user, AdminRole))
        {
            var assignmentResult = await users.AddToRoleAsync(user, AdminRole);
            EnsureSucceeded(assignmentResult, "assign the admin role");
        }
    }

    private static void EnsureSucceeded(IdentityResult result, string operation)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(error => error.Description));
            throw new InvalidOperationException($"Unable to {operation}: {errors}");
        }
    }
}
