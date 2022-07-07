using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProvisioningobjectsummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            AuditLogs_Provisioning,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.AuditLogs_Provisioning: return $"/auditLogs/provisioning";
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
    public partial class ProvisioningobjectsummaryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/provisioningobjectsummary?view=graph-rest-1.0
        /// </summary>
        public partial class ProvisioningObjectSummary
        {
            public enum ProvisioningObjectSummaryProvisioningAction
            {
                Create,
                Update,
                Delete,
                Stageddelete,
                Disable,
                Other,
                UnknownFutureValue,
            }

            public ProvisioningObjectSummaryProvisioningAction ProvisioningAction { get; set; }
            public DateTimeOffset? ActivityDateTime { get; set; }
            public string? ChangeId { get; set; }
            public string? CycleId { get; set; }
            public Int32? DurationInMilliseconds { get; set; }
            public string? Id { get; set; }
            public Initiator? InitiatedBy { get; set; }
            public string? JobId { get; set; }
            public ModifiedProperty[]? ModifiedProperties { get; set; }
            public ProvisioningStep[]? ProvisioningSteps { get; set; }
            public ProvisioningServicePrincipal[]? ServicePrincipal { get; set; }
            public ProvisionedIdentity? SourceIdentity { get; set; }
            public ProvisioningSystem? SourceSystem { get; set; }
            public ProvisioningStatusInfo? ProvisioningStatusInfo { get; set; }
            public ProvisionedIdentity? TargetIdentity { get; set; }
            public ProvisioningSystem? TargetSystem { get; set; }
            public string? TenantId { get; set; }
        }

        public ProvisioningObjectSummary[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ProvisioningobjectsummaryListResponse> ProvisioningobjectsummaryListAsync()
        {
            var p = new ProvisioningobjectsummaryListParameter();
            return await this.SendAsync<ProvisioningobjectsummaryListParameter, ProvisioningobjectsummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ProvisioningobjectsummaryListResponse> ProvisioningobjectsummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new ProvisioningobjectsummaryListParameter();
            return await this.SendAsync<ProvisioningobjectsummaryListParameter, ProvisioningobjectsummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ProvisioningobjectsummaryListResponse> ProvisioningobjectsummaryListAsync(ProvisioningobjectsummaryListParameter parameter)
        {
            return await this.SendAsync<ProvisioningobjectsummaryListParameter, ProvisioningobjectsummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ProvisioningobjectsummaryListResponse> ProvisioningobjectsummaryListAsync(ProvisioningobjectsummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProvisioningobjectsummaryListParameter, ProvisioningobjectsummaryListResponse>(parameter, cancellationToken);
        }
    }
}
