# INVENTRACK VMS™

Industrial valve manufacturing inventory and traceability solution.

## Repository contents
- `Commit-001.zip`, `Commit-002.zip`: earlier package archives.
- `Inventrack-VMS-Commit-002.zip`: uploaded package copy.
- `src/Inventrack.Vms.Api/Security`: Commit 003 permission authorization foundation.
- `src/Inventrack.Vms.Api/Data/HttpTenantContext.cs`: claim-based tenant context.
- `docs/commit-003-security-foundation.md`: scope and integration notes.

## Security status
Commit 003 adds authorization primitives only. Authentication provider configuration, endpoint protection, automated tests, and production hardening remain follow-up work. Do not deploy as production-ready until those steps are completed.
