using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-get?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryAuditGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AuditLogs_DirectoryAudits_Id: return $"/auditLogs/directoryAudits/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            AuditLogs_DirectoryAudits_Id,
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
    public partial class DirectoryAuditGetResponse : RestApiResponse
    {
        public enum DirectoryAuditOperationResult
        {
            Success,
            Failure,
            Timeout,
            UnknownFutureValue,
        }

        public DateTimeOffset? ActivityDateTime { get; set; }
        public string? ActivityDisplayName { get; set; }
        public KeyValue[]? AdditionalDetails { get; set; }
        public string? Category { get; set; }
        public Guid? CorrelationId { get; set; }
        public string? Id { get; set; }
        public AuditActivityInitiator? InitiatedBy { get; set; }
        public string? LoggedByService { get; set; }
        public string? OperationType { get; set; }
        public DirectoryAuditOperationResult Result { get; set; }
        public string? ResultReason { get; set; }
        public TargetResource[]? TargetResources { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditGetResponse> DirectoryAuditGetAsync()
        {
            var p = new DirectoryAuditGetParameter();
            return await this.SendAsync<DirectoryAuditGetParameter, DirectoryAuditGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditGetResponse> DirectoryAuditGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryAuditGetParameter();
            return await this.SendAsync<DirectoryAuditGetParameter, DirectoryAuditGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditGetResponse> DirectoryAuditGetAsync(DirectoryAuditGetParameter parameter)
        {
            return await this.SendAsync<DirectoryAuditGetParameter, DirectoryAuditGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditGetResponse> DirectoryAuditGetAsync(DirectoryAuditGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryAuditGetParameter, DirectoryAuditGetResponse>(parameter, cancellationToken);
        }
    }
}
