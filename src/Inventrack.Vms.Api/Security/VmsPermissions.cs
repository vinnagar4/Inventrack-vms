namespace Inventrack.Vms.Security;

/// <summary>
/// Stable permission keys used by API authorization policies.
/// Keep these values in sync with the identity provider's permission claims.
/// </summary>
public static class VmsPermissions
{
    public const string InventoryRead = "inventory.read";
    public const string InventoryWrite = "inventory.write";
    public const string ProcurementRead = "procurement.read";
    public const string ProcurementWrite = "procurement.write";
    public const string QualityRead = "quality.read";
    public const string QualityRelease = "quality.release";
    public const string TraceabilityRead = "traceability.read";
    public const string UsersManage = "users.manage";

    public static readonly IReadOnlyList<string> All =
    [
        InventoryRead, InventoryWrite,
        ProcurementRead, ProcurementWrite,
        QualityRead, QualityRelease,
        TraceabilityRead, UsersManage
    ];
}
