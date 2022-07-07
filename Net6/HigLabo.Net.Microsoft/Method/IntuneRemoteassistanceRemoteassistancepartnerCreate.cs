using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRemoteassistanceRemoteassistancepartnerCreateParameter : IRestApiParameter
    {
        public enum IntuneRemoteassistanceRemoteassistancepartnerCreateParameterRemoteAssistanceOnboardingStatus
        {
            NotOnboarded,
            Onboarding,
            Onboarded,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? OnboardingUrl { get; set; }
        public IntuneRemoteassistanceRemoteassistancepartnerCreateParameterRemoteAssistanceOnboardingStatus OnboardingStatus { get; set; }
        public DateTimeOffset? LastConnectionDateTime { get; set; }
    }
    public partial class IntuneRemoteassistanceRemoteassistancepartnerCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerCreateResponse> IntuneRemoteassistanceRemoteassistancepartnerCreateAsync()
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerCreateParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerCreateParameter, IntuneRemoteassistanceRemoteassistancepartnerCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerCreateResponse> IntuneRemoteassistanceRemoteassistancepartnerCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerCreateParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerCreateParameter, IntuneRemoteassistanceRemoteassistancepartnerCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerCreateResponse> IntuneRemoteassistanceRemoteassistancepartnerCreateAsync(IntuneRemoteassistanceRemoteassistancepartnerCreateParameter parameter)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerCreateParameter, IntuneRemoteassistanceRemoteassistancepartnerCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerCreateResponse> IntuneRemoteassistanceRemoteassistancepartnerCreateAsync(IntuneRemoteassistanceRemoteassistancepartnerCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerCreateParameter, IntuneRemoteassistanceRemoteassistancepartnerCreateResponse>(parameter, cancellationToken);
        }
    }
}
