using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class Windows10EnterpriseModernAppManagementConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public bool? UninstallBuiltInApps { get; set; }
        }

        public Windows10EnterpriseModernAppManagementConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListAsync(IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListAsync(IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
