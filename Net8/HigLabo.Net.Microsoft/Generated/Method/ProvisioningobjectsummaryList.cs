using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
    /// </summary>
    public partial class ProvisioningobjectSummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AuditLogs_Provisioning: return $"/auditLogs/provisioning";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ActivityDateTime,
            ChangeId,
            CycleId,
            DurationInMilliseconds,
            Id,
            InitiatedBy,
            JobId,
            ModifiedProperties,
            ProvisioningAction,
            ProvisioningStatusInfo,
            ProvisioningSteps,
            ServicePrincipal,
            SourceIdentity,
            SourceSystem,
            TargetIdentity,
            TargetSystem,
            TenantId,
        }
        public enum ApiPath
        {
            AuditLogs_Provisioning,
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
    public partial class ProvisioningobjectSummaryListResponse : RestApiResponse
    {
        public ProvisioningObjectSummary[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningobjectSummaryListResponse> ProvisioningobjectSummaryListAsync()
        {
            var p = new ProvisioningobjectSummaryListParameter();
            return await this.SendAsync<ProvisioningobjectSummaryListParameter, ProvisioningobjectSummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningobjectSummaryListResponse> ProvisioningobjectSummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new ProvisioningobjectSummaryListParameter();
            return await this.SendAsync<ProvisioningobjectSummaryListParameter, ProvisioningobjectSummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningobjectSummaryListResponse> ProvisioningobjectSummaryListAsync(ProvisioningobjectSummaryListParameter parameter)
        {
            return await this.SendAsync<ProvisioningobjectSummaryListParameter, ProvisioningobjectSummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningobjectSummaryListResponse> ProvisioningobjectSummaryListAsync(ProvisioningobjectSummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProvisioningobjectSummaryListParameter, ProvisioningobjectSummaryListResponse>(parameter, cancellationToken);
        }
    }
}
