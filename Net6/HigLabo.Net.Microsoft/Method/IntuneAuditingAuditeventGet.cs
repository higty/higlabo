using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAuditingAuditeventGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_AuditEvents_AuditEventId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_AuditEvents_AuditEventId: return $"/deviceManagement/auditEvents/{AuditEventId}";
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
        public string AuditEventId { get; set; }
    }
    public partial class IntuneAuditingAuditeventGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventGetResponse> IntuneAuditingAuditeventGetAsync()
        {
            var p = new IntuneAuditingAuditeventGetParameter();
            return await this.SendAsync<IntuneAuditingAuditeventGetParameter, IntuneAuditingAuditeventGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventGetResponse> IntuneAuditingAuditeventGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAuditingAuditeventGetParameter();
            return await this.SendAsync<IntuneAuditingAuditeventGetParameter, IntuneAuditingAuditeventGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventGetResponse> IntuneAuditingAuditeventGetAsync(IntuneAuditingAuditeventGetParameter parameter)
        {
            return await this.SendAsync<IntuneAuditingAuditeventGetParameter, IntuneAuditingAuditeventGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventGetResponse> IntuneAuditingAuditeventGetAsync(IntuneAuditingAuditeventGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAuditingAuditeventGetParameter, IntuneAuditingAuditeventGetResponse>(parameter, cancellationToken);
        }
    }
}
