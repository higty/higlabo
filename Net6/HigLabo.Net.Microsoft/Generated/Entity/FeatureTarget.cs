using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/featuretarget?view=graph-rest-1.0
    /// </summary>
    public partial class FeatureTarget
    {
        public enum FeatureTargetFeatureTargetType
        {
            Group,
            AdministrativeUnit,
            Role,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public FeatureTargetFeatureTargetType TargetType { get; set; }
    }
}
