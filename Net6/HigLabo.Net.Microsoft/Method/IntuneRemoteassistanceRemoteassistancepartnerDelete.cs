using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string RemoteAssistancePartnerId { get; set; }
    }
    public partial class IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse> IntuneRemoteassistanceRemoteassistancepartnerDeleteAsync()
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter, IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse> IntuneRemoteassistanceRemoteassistancepartnerDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter();
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter, IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse> IntuneRemoteassistanceRemoteassistancepartnerDeleteAsync(IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter, IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-remoteassistance-remoteassistancepartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse> IntuneRemoteassistanceRemoteassistancepartnerDeleteAsync(IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRemoteassistanceRemoteassistancepartnerDeleteParameter, IntuneRemoteassistanceRemoteassistancepartnerDeleteResponse>(parameter, cancellationToken);
        }
    }
}
