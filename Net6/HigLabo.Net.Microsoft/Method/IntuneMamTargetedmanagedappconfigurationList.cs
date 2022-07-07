using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedappconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneMamTargetedmanagedappconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-targetedmanagedappconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class TargetedManagedAppConfiguration
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

        public TargetedManagedAppConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationListResponse> IntuneMamTargetedmanagedappconfigurationListAsync()
        {
            var p = new IntuneMamTargetedmanagedappconfigurationListParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationListParameter, IntuneMamTargetedmanagedappconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationListResponse> IntuneMamTargetedmanagedappconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedappconfigurationListParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationListParameter, IntuneMamTargetedmanagedappconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationListResponse> IntuneMamTargetedmanagedappconfigurationListAsync(IntuneMamTargetedmanagedappconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationListParameter, IntuneMamTargetedmanagedappconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationListResponse> IntuneMamTargetedmanagedappconfigurationListAsync(IntuneMamTargetedmanagedappconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationListParameter, IntuneMamTargetedmanagedappconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
