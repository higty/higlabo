using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRemoteassistanceRemoteassistancepartnerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RemoteAssistancePartners_RemoteAssistancePartnerId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RemoteAssistancePartners_RemoteAssistancePartnerId: return $"/deviceManagement/remoteAssistancePartners/{RemoteAssistancePartnerId}";
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
        public string RemoteAssistancePartnerId { get; set; }
    }
    public partial class IntuneRemoteassistanceRemoteassistancepartnerGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerGetResponse> IntuneRemoteassistanceRemoteassistancepartnerGetAsync()
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerGetParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerGetParameter, IntuneRemoteassistanceRemoteassistancepartnerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerGetResponse> IntuneRemoteassistanceRemoteassistancepartnerGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerGetParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerGetParameter, IntuneRemoteassistanceRemoteassistancepartnerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerGetResponse> IntuneRemoteassistanceRemoteassistancepartnerGetAsync(IntuneRemoteassistanceRemoteassistancepartnerGetParameter parameter)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerGetParameter, IntuneRemoteassistanceRemoteassistancepartnerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerGetResponse> IntuneRemoteassistanceRemoteassistancepartnerGetAsync(IntuneRemoteassistanceRemoteassistancepartnerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerGetParameter, IntuneRemoteassistanceRemoteassistancepartnerGetResponse>(parameter, cancellationToken);
        }
    }
}
