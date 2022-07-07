using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIoscustomconfigurationCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? PayloadName { get; set; }
        public string? PayloadFileName { get; set; }
        public string? Payload { get; set; }
    }
    public partial class IntuneDeviceconfigIoscustomconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? PayloadName { get; set; }
        public string? PayloadFileName { get; set; }
        public string? Payload { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationCreateResponse> IntuneDeviceconfigIoscustomconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigIoscustomconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationCreateParameter, IntuneDeviceconfigIoscustomconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationCreateResponse> IntuneDeviceconfigIoscustomconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIoscustomconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationCreateParameter, IntuneDeviceconfigIoscustomconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationCreateResponse> IntuneDeviceconfigIoscustomconfigurationCreateAsync(IntuneDeviceconfigIoscustomconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationCreateParameter, IntuneDeviceconfigIoscustomconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationCreateResponse> IntuneDeviceconfigIoscustomconfigurationCreateAsync(IntuneDeviceconfigIoscustomconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationCreateParameter, IntuneDeviceconfigIoscustomconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
