using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappstatusrawGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneMamManagedappstatusrawGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public Json? Content { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawGetResponse> IntuneMamManagedappstatusrawGetAsync()
        {
            var p = new IntuneMamManagedappstatusrawGetParameter();
            return await this.SendAsync<IntuneMamManagedappstatusrawGetParameter, IntuneMamManagedappstatusrawGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawGetResponse> IntuneMamManagedappstatusrawGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappstatusrawGetParameter();
            return await this.SendAsync<IntuneMamManagedappstatusrawGetParameter, IntuneMamManagedappstatusrawGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawGetResponse> IntuneMamManagedappstatusrawGetAsync(IntuneMamManagedappstatusrawGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappstatusrawGetParameter, IntuneMamManagedappstatusrawGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawGetResponse> IntuneMamManagedappstatusrawGetAsync(IntuneMamManagedappstatusrawGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappstatusrawGetParameter, IntuneMamManagedappstatusrawGetResponse>(parameter, cancellationToken);
        }
    }
}
