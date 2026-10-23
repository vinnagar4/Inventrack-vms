using Microsoft.AspNetCore.Authorization;

namespace Inventrack.Vms.Security;

public sealed record PermissionRequirement(string Permission) : IAuthorizationRequirement;
