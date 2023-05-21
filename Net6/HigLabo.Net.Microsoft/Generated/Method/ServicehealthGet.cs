using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
    /// </summary>
    public partial class ServicehealthGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServiceName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_HealthOverviews_ServiceName: return $"/admin/serviceAnnouncement/healthOverviews/{ServiceName}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_HealthOverviews_ServiceName,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
        public ServiceHealthIssue[]? Issues { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync()
        {
            var p = new ServicehealthGetParameter();
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync(CancellationToken cancellationToken)
        {
            var p = new ServicehealthGetParameter();
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync(ServicehealthGetParameter parameter)
        {
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/servicehealth-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthGetResponse> ServicehealthGetAsync(ServicehealthGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicehealthGetParameter, ServicehealthGetResponse>(parameter, cancellationToken);
        }
    }
}
