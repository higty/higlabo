using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedappconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}";
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
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamTargetedmanagedappconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationGetResponse> IntuneMamTargetedmanagedappconfigurationGetAsync()
        {
            var p = new IntuneMamTargetedmanagedappconfigurationGetParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationGetParameter, IntuneMamTargetedmanagedappconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationGetResponse> IntuneMamTargetedmanagedappconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedappconfigurationGetParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationGetParameter, IntuneMamTargetedmanagedappconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationGetResponse> IntuneMamTargetedmanagedappconfigurationGetAsync(IntuneMamTargetedmanagedappconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationGetParameter, IntuneMamTargetedmanagedappconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationGetResponse> IntuneMamTargetedmanagedappconfigurationGetAsync(IntuneMamTargetedmanagedappconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationGetParameter, IntuneMamTargetedmanagedappconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
