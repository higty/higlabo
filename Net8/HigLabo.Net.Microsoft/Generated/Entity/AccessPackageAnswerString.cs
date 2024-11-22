using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageanswerstring?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageAnswerString
{
    public AccessPackageQuestion? AnsweredQuestion { get; set; }
    public string? DisplayValue { get; set; }
    public string? Value { get; set; }
}
