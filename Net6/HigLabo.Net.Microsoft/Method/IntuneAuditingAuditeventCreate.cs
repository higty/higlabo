using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAuditingAuditeventCreateParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public partial class IntuneAuditingAuditeventCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventCreateResponse> IntuneAuditingAuditeventCreateAsync()
        {
            var p = new IntuneAuditingAuditeventCreateParameter();
            return await this.SendAsync<IntuneAuditingAuditeventCreateParameter, IntuneAuditingAuditeventCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventCreateResponse> IntuneAuditingAuditeventCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAuditingAuditeventCreateParameter();
            return await this.SendAsync<IntuneAuditingAuditeventCreateParameter, IntuneAuditingAuditeventCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventCreateResponse> IntuneAuditingAuditeventCreateAsync(IntuneAuditingAuditeventCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAuditingAuditeventCreateParameter, IntuneAuditingAuditeventCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventCreateResponse> IntuneAuditingAuditeventCreateAsync(IntuneAuditingAuditeventCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAuditingAuditeventCreateParameter, IntuneAuditingAuditeventCreateResponse>(parameter, cancellationToken);
        }
    }
}
