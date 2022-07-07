using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappstatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppStatuses: return $"/deviceAppManagement/managedAppStatuses";
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
    public partial class IntuneMamManagedappstatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappstatus?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedAppStatus
        {
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? Version { get; set; }
        }

        public ManagedAppStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusListResponse> IntuneMamManagedappstatusListAsync()
        {
            var p = new IntuneMamManagedappstatusListParameter();
            return await this.SendAsync<IntuneMamManagedappstatusListParameter, IntuneMamManagedappstatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusListResponse> IntuneMamManagedappstatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappstatusListParameter();
            return await this.SendAsync<IntuneMamManagedappstatusListParameter, IntuneMamManagedappstatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusListResponse> IntuneMamManagedappstatusListAsync(IntuneMamManagedappstatusListParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappstatusListParameter, IntuneMamManagedappstatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusListResponse> IntuneMamManagedappstatusListAsync(IntuneMamManagedappstatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappstatusListParameter, IntuneMamManagedappstatusListResponse>(parameter, cancellationToken);
        }
    }
}
