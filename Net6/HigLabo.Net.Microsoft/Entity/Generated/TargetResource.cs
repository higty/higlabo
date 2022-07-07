using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/targetresource?view=graph-rest-1.0
    /// </summary>
    public partial class TargetResource
    {
        public enum TargetResourceGroupType
        {
            Group,
            UnifiedGroups,
            AzureAD,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Type { get; set; }
        public string? UserPrincipalName { get; set; }
        public TargetResourceGroupType GroupType { get; set; }
        public ModifiedProperty[]? ModifiedProperties { get; set; }
    }
}
