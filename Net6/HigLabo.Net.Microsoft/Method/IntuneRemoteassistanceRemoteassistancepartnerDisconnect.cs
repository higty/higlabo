using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_RemoteAssistancePartners_RemoteAssistancePartnerId_Disconnect,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RemoteAssistancePartners_RemoteAssistancePartnerId_Disconnect: return $"/deviceManagement/remoteAssistancePartners/{RemoteAssistancePartnerId}/disconnect";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string RemoteAssistancePartnerId { get; set; }
    }
    public partial class IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-disconnect?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse> IntuneRemoteassistanceRemoteassistancepartnerDisconnectAsync()
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter, IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-disconnect?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse> IntuneRemoteassistanceRemoteassistancepartnerDisconnectAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter, IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-disconnect?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse> IntuneRemoteassistanceRemoteassistancepartnerDisconnectAsync(IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter parameter)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter, IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-disconnect?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse> IntuneRemoteassistanceRemoteassistancepartnerDisconnectAsync(IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDisconnectParameter, IntuneRemoteassistanceRemoteassistancepartnerDisconnectResponse>(parameter, cancellationToken);
        }
    }
}
