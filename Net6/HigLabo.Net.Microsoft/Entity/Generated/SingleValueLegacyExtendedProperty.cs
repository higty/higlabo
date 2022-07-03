using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/singlevaluelegacyextendedproperty?view=graph-rest-1.0
    /// </summary>
    public partial class SingleValueLegacyExtendedProperty
    {
        public String? Id { get; set; }
        public String? Value { get; set; }
    }
}
