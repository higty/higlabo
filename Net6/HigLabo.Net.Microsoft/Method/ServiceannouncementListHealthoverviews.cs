using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceannouncementListHealthoverviewsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_HealthOverviews,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_HealthOverviews: return $"/admin/serviceAnnouncement/healthOverviews";
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
    public partial class ServiceannouncementListHealthoverviewsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/servicehealth?view=graph-rest-1.0
        /// </summary>
        public partial class ServiceHealth
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

        public ServiceHealth[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync()
        {
            var p = new ServiceannouncementListHealthoverviewsParameter();
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceannouncementListHealthoverviewsParameter();
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(ServiceannouncementListHealthoverviewsParameter parameter)
        {
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(ServiceannouncementListHealthoverviewsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(parameter, cancellationToken);
        }
    }
}
