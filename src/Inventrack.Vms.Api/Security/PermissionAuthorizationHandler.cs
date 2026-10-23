using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Inventrack.Vms.Security;

/// <summary>
/// Grants a policy only when the authenticated principal carries the exact permission claim.
/// Authentication and claim issuance must be configured by a trusted identity provider.
/// </summary>
public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    public const string PermissionClaimType = "permission";

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if (context.User.Identity?.IsAuthenticated == true &&
            context.User.Claims.Any(claim =>
                claim.Type == PermissionClaimType &&
                string.Equals(claim.Value, requirement.Permission, StringComparison.Ordinal)))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
