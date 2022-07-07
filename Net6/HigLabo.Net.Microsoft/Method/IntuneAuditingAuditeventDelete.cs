using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAuditingAuditeventDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AuditEventId { get; set; }
    }
    public partial class IntuneAuditingAuditeventDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventDeleteResponse> IntuneAuditingAuditeventDeleteAsync()
        {
            var p = new IntuneAuditingAuditeventDeleteParameter();
            return await this.SendAsync<IntuneAuditingAuditeventDeleteParameter, IntuneAuditingAuditeventDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventDeleteResponse> IntuneAuditingAuditeventDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAuditingAuditeventDeleteParameter();
            return await this.SendAsync<IntuneAuditingAuditeventDeleteParameter, IntuneAuditingAuditeventDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventDeleteResponse> IntuneAuditingAuditeventDeleteAsync(IntuneAuditingAuditeventDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAuditingAuditeventDeleteParameter, IntuneAuditingAuditeventDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-auditevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingAuditeventDeleteResponse> IntuneAuditingAuditeventDeleteAsync(IntuneAuditingAuditeventDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAuditingAuditeventDeleteParameter, IntuneAuditingAuditeventDeleteResponse>(parameter, cancellationToken);
        }
    }
}
