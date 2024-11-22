using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/scopedrolemembership?view=graph-rest-1.0
/// </summary>
public partial class ScopedRoleMembership
{
    public string? AdministrativeUnitId { get; set; }
    public string? Id { get; set; }
    public string? RoleId { get; set; }
    public Identity? RoleMemberInfo { get; set; }
}
