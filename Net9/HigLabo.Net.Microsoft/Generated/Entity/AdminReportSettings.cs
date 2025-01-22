using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/adminreportsettings?view=graph-rest-1.0
/// </summary>
public partial class AdminReportSettings
{
    public bool? DisplayConcealedNames { get; set; }
}
