using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkforceintegrationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string WorkforceIntegrationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teamwork_WorkforceIntegrations_WorkforceIntegrationId: return $"/teamwork/workforceIntegrations/{WorkforceIntegrationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teamwork_WorkforceIntegrations_WorkforceIntegrationId,
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
    public partial class WorkforceintegrationGetResponse : RestApiResponse
    {
        public enum WorkforceIntegrationWorkforceIntegrationSupportedEntities
        {
            None,
            Shift,
            SwapRequest,
            UserShiftPreferences,
            Openshift,
            OpenShiftRequest,
            OfferShiftRequest,
            UnknownFutureValue,
        }

        public Int32? ApiVersion { get; set; }
        public string? DisplayName { get; set; }
        public WorkforceIntegrationEncryption? Encryption { get; set; }
        public bool? IsActive { get; set; }
        public WorkforceIntegrationWorkforceIntegrationSupportedEntities SupportedEntities { get; set; }
        public string? Url { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationGetResponse> WorkforceintegrationGetAsync()
        {
            var p = new WorkforceintegrationGetParameter();
            return await this.SendAsync<WorkforceintegrationGetParameter, WorkforceintegrationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationGetResponse> WorkforceintegrationGetAsync(CancellationToken cancellationToken)
        {
            var p = new WorkforceintegrationGetParameter();
            return await this.SendAsync<WorkforceintegrationGetParameter, WorkforceintegrationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationGetResponse> WorkforceintegrationGetAsync(WorkforceintegrationGetParameter parameter)
        {
            return await this.SendAsync<WorkforceintegrationGetParameter, WorkforceintegrationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationGetResponse> WorkforceintegrationGetAsync(WorkforceintegrationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkforceintegrationGetParameter, WorkforceintegrationGetResponse>(parameter, cancellationToken);
        }
    }
}
