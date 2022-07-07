using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAuditingAuditeventListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_AuditEvents,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_AuditEvents: return $"/deviceManagement/auditEvents";
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
    public partial class IntuneAuditingAuditeventListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-auditing-auditevent?view=graph-rest-1.0
        /// </summary>
        public partial class AuditEvent
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? ComponentName { get; set; }
            public AuditActor? Actor { get; set; }
            public string? Activity { get; set; }
            public DateTimeOffset? ActivityDateTime { get; set; }
            public string? ActivityType { get; set; }
            public string? ActivityOperationType { get; set; }
            public string? ActivityResult { get; set; }
            public Guid? CorrelationId { get; set; }
            public AuditResource[]? Resources { get; set; }
            public string? Category { get; set; }
        }

        public AuditEvent[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventListResponse> IntuneAuditingAuditeventListAsync()
        {
            var p = new IntuneAuditingAuditeventListParameter();
            return await this.SendAsync<IntuneAuditingAuditeventListParameter, IntuneAuditingAuditeventListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventListResponse> IntuneAuditingAuditeventListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAuditingAuditeventListParameter();
            return await this.SendAsync<IntuneAuditingAuditeventListParameter, IntuneAuditingAuditeventListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventListResponse> IntuneAuditingAuditeventListAsync(IntuneAuditingAuditeventListParameter parameter)
        {
            return await this.SendAsync<IntuneAuditingAuditeventListParameter, IntuneAuditingAuditeventListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventListResponse> IntuneAuditingAuditeventListAsync(IntuneAuditingAuditeventListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAuditingAuditeventListParameter, IntuneAuditingAuditeventListResponse>(parameter, cancellationToken);
        }
    }
}
