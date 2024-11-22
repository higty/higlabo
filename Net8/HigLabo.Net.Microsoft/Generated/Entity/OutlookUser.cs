using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/outlookuser?view=graph-rest-1.0
/// </summary>
public partial class OutlookUser
{
    public OutlookCategory[]? MasterCategories { get; set; }
}
