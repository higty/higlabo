using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_RemoteAssistancePartners_RemoteAssistancePartnerId_BeginOnboarding,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RemoteAssistancePartners_RemoteAssistancePartnerId_BeginOnboarding: return $"/deviceManagement/remoteAssistancePartners/{RemoteAssistancePartnerId}/beginOnboarding";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string RemoteAssistancePartnerId { get; set; }
    }
    public partial class IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-beginonboarding?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse> IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingAsync()
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter, IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-beginonboarding?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse> IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter, IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-beginonboarding?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse> IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingAsync(IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter parameter)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter, IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-beginonboarding?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse> IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingAsync(IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingParameter, IntuneRemoteassistanceRemoteassistancepartnerBeginonboardingResponse>(parameter, cancellationToken);
        }
    }
}
