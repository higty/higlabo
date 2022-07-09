using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryauditListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AuditLogs_Directoryaudits: return $"/auditLogs/directoryaudits";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ActivityDateTime,
            ActivityDisplayName,
            AdditionalDetails,
            Category,
            CorrelationId,
            Id,
            InitiatedBy,
            OperationType,
            LoggedByService,
            Result,
            ResultReason,
            TargetResources,
        }
        public enum ApiPath
        {
            AuditLogs_Directoryaudits,
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
    public partial class DirectoryauditListResponse : RestApiResponse
    {
        public DirectoryAudit[]? Value { get; set; }
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
