using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesUserRemovealldevicesfrommanagementParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_RemoveAllDevicesFromManagement,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_RemoveAllDevicesFromManagement: return $"/users/{UsersId}/removeAllDevicesFromManagement";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
    }
    public partial class IntuneDevicesUserRemovealldevicesfrommanagementResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-removealldevicesfrommanagement?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserRemovealldevicesfrommanagementResponse> IntuneDevicesUserRemovealldevicesfrommanagementAsync()
        {
            var p = new IntuneDevicesUserRemovealldevicesfrommanagementParameter();
            return await this.SendAsync<IntuneDevicesUserRemovealldevicesfrommanagementParameter, IntuneDevicesUserRemovealldevicesfrommanagementResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-removealldevicesfrommanagement?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserRemovealldevicesfrommanagementResponse> IntuneDevicesUserRemovealldevicesfrommanagementAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesUserRemovealldevicesfrommanagementParameter();
            return await this.SendAsync<IntuneDevicesUserRemovealldevicesfrommanagementParameter, IntuneDevicesUserRemovealldevicesfrommanagementResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-removealldevicesfrommanagement?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserRemovealldevicesfrommanagementResponse> IntuneDevicesUserRemovealldevicesfrommanagementAsync(IntuneDevicesUserRemovealldevicesfrommanagementParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesUserRemovealldevicesfrommanagementParameter, IntuneDevicesUserRemovealldevicesfrommanagementResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-removealldevicesfrommanagement?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserRemovealldevicesfrommanagementResponse> IntuneDevicesUserRemovealldevicesfrommanagementAsync(IntuneDevicesUserRemovealldevicesfrommanagementParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesUserRemovealldevicesfrommanagementParameter, IntuneDevicesUserRemovealldevicesfrommanagementResponse>(parameter, cancellationToken);
        }
    }
}
