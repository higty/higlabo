using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-parameter?view=graph-rest-1.0
    /// </summary>
    public partial class Parameter
    {
        public enum ParameterIdentityGovernanceValueType
        {
            Enum,
            String,
            Int,
            Bool,
            UnknownFutureValue,
        }

        public string? Name { get; set; }
        public String[]? Values { get; set; }
        public ParameterIdentityGovernanceValueType ValueType { get; set; }
    }
}
