using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-propertyrule?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsPropertyrule
{
    public enum ExternalConnectorsPropertyruleExternalConnectorsRuleOperation
    {
        Property,
        Values,
        Null,
        Equals,
        NotEquals,
        Contains,
        NotContains,
        LessThan,
        GreaterThan,
        StartsWith,
    }
    public enum ExternalConnectorsPropertyruleBinaryOperator
    {
        And,
        Or,
    }

    public ExternalConnectorsPropertyruleExternalConnectorsRuleOperation Operation { get; set; }
    public string? Property { get; set; }
    public String[]? Values { get; set; }
    public ExternalConnectorsPropertyruleBinaryOperator ValuesJoinedBy { get; set; }
}
