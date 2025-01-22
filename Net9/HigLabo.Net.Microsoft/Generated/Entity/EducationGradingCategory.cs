using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/educationgradingcategory?view=graph-rest-1.0
/// </summary>
public partial class EducationGradingCategory
{
    public string? Id { get; set; }
    public string? DisplayName { get; set; }
    public Int32? PercentageWeight { get; set; }
}
