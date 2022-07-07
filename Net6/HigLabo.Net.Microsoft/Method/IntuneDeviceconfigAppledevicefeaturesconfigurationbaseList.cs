using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-appledevicefeaturesconfigurationbase?view=graph-rest-1.0
        /// </summary>
        public partial class AppleDeviceFeaturesConfigurationBase
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
        }

        public AppleDeviceFeaturesConfigurationBase[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-appledevicefeaturesconfigurationbase-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse> IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListAsync()
        {
            var p = new IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter();
            return await this.SendAsync<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter, IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-appledevicefeaturesconfigurationbase-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse> IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter();
            return await this.SendAsync<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter, IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-appledevicefeaturesconfigurationbase-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse> IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListAsync(IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter, IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-appledevicefeaturesconfigurationbase-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse> IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListAsync(IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListParameter, IntuneDeviceconfigAppledevicefeaturesconfigurationbaseListResponse>(parameter, cancellationToken);
        }
    }
}
