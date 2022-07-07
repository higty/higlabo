using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedappconfigurationCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_TargetedManagedAppConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations: return $"/deviceAppManagement/targetedManagedAppConfigurations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public KeyValuePair[]? CustomSettings { get; set; }
        public Int32? DeployedAppCount { get; set; }
        public bool? IsAssigned { get; set; }
    }
    public partial class IntuneMamTargetedmanagedappconfigurationCreateResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public KeyValuePair[]? CustomSettings { get; set; }
        public Int32? DeployedAppCount { get; set; }
        public bool? IsAssigned { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationCreateResponse> IntuneMamTargetedmanagedappconfigurationCreateAsync()
        {
            var p = new IntuneMamTargetedmanagedappconfigurationCreateParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationCreateParameter, IntuneMamTargetedmanagedappconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationCreateResponse> IntuneMamTargetedmanagedappconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedappconfigurationCreateParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationCreateParameter, IntuneMamTargetedmanagedappconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationCreateResponse> IntuneMamTargetedmanagedappconfigurationCreateAsync(IntuneMamTargetedmanagedappconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationCreateParameter, IntuneMamTargetedmanagedappconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationCreateResponse> IntuneMamTargetedmanagedappconfigurationCreateAsync(IntuneMamTargetedmanagedappconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationCreateParameter, IntuneMamTargetedmanagedappconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
