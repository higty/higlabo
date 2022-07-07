using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceannouncementListIssuesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Issues,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Issues: return $"/admin/serviceAnnouncement/issues";
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
    public partial class ServiceannouncementListIssuesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/servicehealthissue?view=graph-rest-1.0
        /// </summary>
        public partial class ServiceHealthIssue
        {
            public enum ServiceHealthIssueServiceHealthClassificationType
            {
                Advisory,
                Incident,
                UnknownFutureValue,
            }
            public enum ServiceHealthIssueServiceHealthOrigin
            {
                Microsoft,
                ThirdParty,
                Customer,
                UnknownFutureValue,
            }
            public enum ServiceHealthIssueServiceHealthStatus
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

            public ServiceHealthIssueServiceHealthClassificationType Classification { get; set; }
            public KeyValuePair[]? Details { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
            public string? Feature { get; set; }
            public string? FeatureGroup { get; set; }
            public string? Id { get; set; }
            public string? ImpactDescription { get; set; }
            public bool? IsResolved { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public ServiceHealthIssueServiceHealthOrigin Origin { get; set; }
            public ServiceHealthIssuePost[]? Posts { get; set; }
            public string? Service { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public ServiceHealthIssueServiceHealthStatus Status { get; set; }
            public string? Title { get; set; }
        }

        public ServiceHealthIssue[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync()
        {
            var p = new ServiceannouncementListIssuesParameter();
            return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceannouncementListIssuesParameter();
            return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync(ServiceannouncementListIssuesParameter parameter)
        {
            return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync(ServiceannouncementListIssuesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(parameter, cancellationToken);
        }
    }
}
