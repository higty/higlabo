using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesDetectedappCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DetectedApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DetectedApps: return $"/deviceManagement/detectedApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Version { get; set; }
        public Int64? SizeInByte { get; set; }
        public Int32? DeviceCount { get; set; }
    }
    public partial class IntuneDevicesDetectedappCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Version { get; set; }
        public Int64? SizeInByte { get; set; }
        public Int32? DeviceCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappCreateResponse> IntuneDevicesDetectedappCreateAsync()
        {
            var p = new IntuneDevicesDetectedappCreateParameter();
            return await this.SendAsync<IntuneDevicesDetectedappCreateParameter, IntuneDevicesDetectedappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappCreateResponse> IntuneDevicesDetectedappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesDetectedappCreateParameter();
            return await this.SendAsync<IntuneDevicesDetectedappCreateParameter, IntuneDevicesDetectedappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappCreateResponse> IntuneDevicesDetectedappCreateAsync(IntuneDevicesDetectedappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesDetectedappCreateParameter, IntuneDevicesDetectedappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappCreateResponse> IntuneDevicesDetectedappCreateAsync(IntuneDevicesDetectedappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesDetectedappCreateParameter, IntuneDevicesDetectedappCreateResponse>(parameter, cancellationToken);
        }
    }
}
