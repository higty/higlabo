using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesUserDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId: return $"/users/{UsersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string UsersId { get; set; }
    }
    public partial class IntuneDevicesUserDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserDeleteResponse> IntuneDevicesUserDeleteAsync()
        {
            var p = new IntuneDevicesUserDeleteParameter();
            return await this.SendAsync<IntuneDevicesUserDeleteParameter, IntuneDevicesUserDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserDeleteResponse> IntuneDevicesUserDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesUserDeleteParameter();
            return await this.SendAsync<IntuneDevicesUserDeleteParameter, IntuneDevicesUserDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserDeleteResponse> IntuneDevicesUserDeleteAsync(IntuneDevicesUserDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesUserDeleteParameter, IntuneDevicesUserDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserDeleteResponse> IntuneDevicesUserDeleteAsync(IntuneDevicesUserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesUserDeleteParameter, IntuneDevicesUserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
