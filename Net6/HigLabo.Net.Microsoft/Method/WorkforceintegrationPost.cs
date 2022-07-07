using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkforceintegrationPostParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class WorkforceintegrationPostResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync()
        {
            var p = new WorkforceintegrationPostParameter();
            return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync(CancellationToken cancellationToken)
        {
            var p = new WorkforceintegrationPostParameter();
            return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync(WorkforceintegrationPostParameter parameter)
        {
            return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync(WorkforceintegrationPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(parameter, cancellationToken);
        }
    }
}
