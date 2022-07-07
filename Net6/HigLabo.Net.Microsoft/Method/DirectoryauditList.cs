using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryauditListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            AuditLogs_Directoryaudits,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.AuditLogs_Directoryaudits: return $"/auditLogs/directoryaudits";
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
    public partial class DirectoryauditListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryaudit?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryAudit
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
            public string? OperationType { get; set; }
            public string? LoggedByService { get; set; }
            public DirectoryAuditOperationResult Result { get; set; }
            public string? ResultReason { get; set; }
            public TargetResource[]? TargetResources { get; set; }
        }

        public DirectoryAudit[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryauditListResponse> DirectoryauditListAsync()
        {
            var p = new DirectoryauditListParameter();
            return await this.SendAsync<DirectoryauditListParameter, DirectoryauditListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryauditListResponse> DirectoryauditListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryauditListParameter();
            return await this.SendAsync<DirectoryauditListParameter, DirectoryauditListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryauditListResponse> DirectoryauditListAsync(DirectoryauditListParameter parameter)
        {
            return await this.SendAsync<DirectoryauditListParameter, DirectoryauditListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryauditListResponse> DirectoryauditListAsync(DirectoryauditListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryauditListParameter, DirectoryauditListResponse>(parameter, cancellationToken);
        }
    }
}
