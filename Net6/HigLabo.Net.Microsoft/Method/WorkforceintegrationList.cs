using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkforceintegrationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teamwork_WorkforceIntegrations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teamwork_WorkforceIntegrations: return $"/teamwork/workforceIntegrations";
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
    public partial class WorkforceintegrationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/workforceintegration?view=graph-rest-1.0
        /// </summary>
        public partial class WorkforceIntegration
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

        public WorkforceIntegration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync()
        {
            var p = new WorkforceintegrationListParameter();
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync(CancellationToken cancellationToken)
        {
            var p = new WorkforceintegrationListParameter();
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync(WorkforceintegrationListParameter parameter)
        {
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync(WorkforceintegrationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(parameter, cancellationToken);
        }
    }
}
