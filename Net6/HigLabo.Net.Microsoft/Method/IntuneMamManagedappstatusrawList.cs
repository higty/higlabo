using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappstatusrawListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneMamManagedappstatusrawListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappstatusraw?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedAppStatusRaw
        {
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? Version { get; set; }
            public Json? Content { get; set; }
        }

        public ManagedAppStatusRaw[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawListResponse> IntuneMamManagedappstatusrawListAsync()
        {
            var p = new IntuneMamManagedappstatusrawListParameter();
            return await this.SendAsync<IntuneMamManagedappstatusrawListParameter, IntuneMamManagedappstatusrawListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawListResponse> IntuneMamManagedappstatusrawListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappstatusrawListParameter();
            return await this.SendAsync<IntuneMamManagedappstatusrawListParameter, IntuneMamManagedappstatusrawListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawListResponse> IntuneMamManagedappstatusrawListAsync(IntuneMamManagedappstatusrawListParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappstatusrawListParameter, IntuneMamManagedappstatusrawListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappstatusraw-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappstatusrawListResponse> IntuneMamManagedappstatusrawListAsync(IntuneMamManagedappstatusrawListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappstatusrawListParameter, IntuneMamManagedappstatusrawListResponse>(parameter, cancellationToken);
        }
    }
}
