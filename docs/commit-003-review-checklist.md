# Commit 003 review checklist

- [ ] Configure a trusted OIDC/JWT authentication provider.
- [ ] Confirm the provider issues the expected `tenant_id` and `permission` claims.
- [ ] Register `AddInventrackAuthorization()` and authentication/authorization middleware.
- [ ] Apply policies to every business endpoint (default-deny recommended).
- [ ] Confirm null tenant context returns no tenant-owned data.
- [ ] Add automated tests for permission and tenant isolation.
- [ ] Run `dotnet build` and `dotnet test` before deployment.
- [ ] Review role-to-permission mapping with the business owner.
