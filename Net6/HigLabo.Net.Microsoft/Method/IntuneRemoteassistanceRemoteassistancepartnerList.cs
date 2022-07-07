using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRemoteassistanceRemoteassistancepartnerListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RemoteAssistancePartners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RemoteAssistancePartners: return $"/deviceManagement/remoteAssistancePartners";
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
    public partial class IntuneRemoteassistanceRemoteassistancepartnerListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-remoteassistance-remoteassistancepartner?view=graph-rest-1.0
        /// </summary>
        public partial class RemoteAssistancePartner
        {
            public enum RemoteAssistancePartnerRemoteAssistanceOnboardingStatus
            {
                NotOnboarded,
                Onboarding,
                Onboarded,
            }

            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? OnboardingUrl { get; set; }
            public RemoteAssistanceOnboardingStatus? OnboardingStatus { get; set; }
            public DateTimeOffset? LastConnectionDateTime { get; set; }
        }

        public RemoteAssistancePartner[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerListResponse> IntuneRemoteassistanceRemoteassistancepartnerListAsync()
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerListParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerListParameter, IntuneRemoteassistanceRemoteassistancepartnerListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerListResponse> IntuneRemoteassistanceRemoteassistancepartnerListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerListParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerListParameter, IntuneRemoteassistanceRemoteassistancepartnerListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerListResponse> IntuneRemoteassistanceRemoteassistancepartnerListAsync(IntuneRemoteassistanceRemoteassistancepartnerListParameter parameter)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerListParameter, IntuneRemoteassistanceRemoteassistancepartnerListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerListResponse> IntuneRemoteassistanceRemoteassistancepartnerListAsync(IntuneRemoteassistanceRemoteassistancepartnerListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerListParameter, IntuneRemoteassistanceRemoteassistancepartnerListResponse>(parameter, cancellationToken);
        }
    }
}
