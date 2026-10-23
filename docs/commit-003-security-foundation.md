# Commit 003 — Authorization and tenant identity foundation

## Included
- Stable permission keys for inventory, procurement, quality, traceability, and user administration.
- A policy requirement and authorization handler that checks exact `permission` claims.
- An HTTP tenant context that resolves `tenant_id` and actor ID from an authenticated principal.
- A service-registration extension for permission policies and claim-based tenant context.

## Important security boundary
This commit is a **security foundation, not a complete login implementation**. It does not configure JWT/OIDC authentication, create users, issue tokens, or assign roles. The application host must configure a trusted identity provider before any business endpoint is protected with these policies. Never accept a tenant ID from a request body, query parameter, or caller-controlled header.

## Policy names
Use `AuthorizationServiceCollectionExtensions.ToPolicyName(permission)`, for example:
- `permission:inventory.read`
- `permission:inventory.write`
- `permission:procurement.read`
- `permission:procurement.write`
- `permission:quality.read`
- `permission:quality.release`
- `permission:traceability.read`
- `permission:users.manage`

## Integration notes
1. Register with `builder.Services.AddInventrackAuthorization()` after selecting/configuring the authentication scheme.
2. Configure authentication middleware with `app.UseAuthentication()` before `app.UseAuthorization()`.
3. Protect each business endpoint explicitly, e.g. `.RequireAuthorization(AuthorizationServiceCollectionExtensions.ToPolicyName(VmsPermissions.InventoryRead))`.
4. Ensure EF Core tenant filters fail closed when `ITenantContext.TenantId` is null. Do not use a shared mutable singleton tenant context in a multi-user host.
5. Add tests for missing claims, invalid tenant IDs, unauthenticated principals, permission mismatch, and cross-tenant access before production use.

## Validation status
Source-level foundation only. Build, unit tests, identity-provider integration, and tenant-isolation tests have not been run in this environment.
