using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappstatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppStatuses_ManagedAppStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppStatuses_ManagedAppStatusId: return $"/deviceAppManagement/managedAppStatuses/{ManagedAppStatusId}";
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
        public string ManagedAppStatusId { get; set; }
    }
    public partial class IntuneMamManagedappstatusGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusGetResponse> IntuneMamManagedappstatusGetAsync()
        {
            var p = new IntuneMamManagedappstatusGetParameter();
            return await this.SendAsync<IntuneMamManagedappstatusGetParameter, IntuneMamManagedappstatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusGetResponse> IntuneMamManagedappstatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappstatusGetParameter();
            return await this.SendAsync<IntuneMamManagedappstatusGetParameter, IntuneMamManagedappstatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusGetResponse> IntuneMamManagedappstatusGetAsync(IntuneMamManagedappstatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappstatusGetParameter, IntuneMamManagedappstatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusGetResponse> IntuneMamManagedappstatusGetAsync(IntuneMamManagedappstatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappstatusGetParameter, IntuneMamManagedappstatusGetResponse>(parameter, cancellationToken);
        }
    }
}
