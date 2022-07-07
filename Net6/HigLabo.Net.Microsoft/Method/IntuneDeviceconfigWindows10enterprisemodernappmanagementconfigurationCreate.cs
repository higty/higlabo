using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter : IRestApiParameter
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
        public bool? UninstallBuiltInApps { get; set; }
    }
    public partial class IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? UninstallBuiltInApps { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateAsync(IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateAsync(IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
