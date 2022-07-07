using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServicehealthGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_HealthOverviews_ServiceName,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_HealthOverviews_ServiceName: return $"/admin/serviceAnnouncement/healthOverviews/{ServiceName}";
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
        public string ServiceName { get; set; }
    }
    public partial class ServicehealthGetResponse : RestApiResponse
    {
        public enum ServiceHealthServiceHealthStatus
        {
            ServiceOperational,
            Investigating,
            RestoringService,
            VerifyingService,
            ServiceRestored,
            PostIncidentReviewPublished,
            ServiceDegradation,
            ServiceInterruption,
            ExtendedRecovery,
            FalsePositive,
            InvestigationSuspended,
            Resolved,
            MitigatedExternal,
            Mitigated,
            ResolvedExternal,
            Confirmed,
            Reported,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public string? Service { get; set; }
        public ServiceHealthServiceHealthStatus Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync()
        {
            var p = new ServicehealthGetParameter();
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync(CancellationToken cancellationToken)
        {
            var p = new ServicehealthGetParameter();
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync(ServicehealthGetParameter parameter)
        {
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync(ServicehealthGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(parameter, cancellationToken);
        }
    }
}
