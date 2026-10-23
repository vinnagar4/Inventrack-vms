using Inventrack.Vms.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Inventrack.Vms.Security;

/// <summary>
/// Registers permission policies and claim-based tenant context.
/// This does not configure an authentication scheme; the host must configure a trusted
/// OIDC/JWT provider before protecting business endpoints with these policies.
/// </summary>
public static class AuthorizationServiceCollectionExtensions
{
    public static IServiceCollection AddInventrackAuthorization(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ITenantContext, HttpTenantContext>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddAuthorization(options =>
        {
            foreach (var permission in VmsPermissions.All)
            {
                var policyName = ToPolicyName(permission);
                options.AddPolicy(policyName, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new PermissionRequirement(permission));
                });
            }
        });

        return services;
    }

    public static string ToPolicyName(string permission) =>
        "permission:" + permission;
}
