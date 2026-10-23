using System.Security.Claims;

namespace Inventrack.Vms.Data;

/// <summary>
/// Resolves tenant and actor identifiers from authenticated claims.
/// Never trust tenant identifiers supplied in request bodies, query strings, or headers.
/// A missing or invalid tenant claim intentionally resolves to null.
/// </summary>
public sealed class HttpTenantContext(IHttpContextAccessor httpContextAccessor) : ITenantContext
{
    public Guid? TenantId
    {
        get
        {
            var principal = httpContextAccessor.HttpContext?.User;
            if (principal?.Identity?.IsAuthenticated != true)
                return null;

            var raw = principal.FindFirstValue("tenant_id");
            return Guid.TryParse(raw, out var tenantId) ? tenantId : null;
        }
    }

    public string? ActorId
    {
        get
        {
            var principal = httpContextAccessor.HttpContext?.User;
            if (principal?.Identity?.IsAuthenticated != true)
                return null;

            return principal.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? principal.FindFirstValue("sub");
        }
    }
}
