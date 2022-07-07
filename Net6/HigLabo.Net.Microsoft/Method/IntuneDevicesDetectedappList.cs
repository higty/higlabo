using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesDetectedappListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class IntuneDevicesDetectedappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-detectedapp?view=graph-rest-1.0
        /// </summary>
        public partial class DetectedApp
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Version { get; set; }
            public Int64? SizeInByte { get; set; }
            public Int32? DeviceCount { get; set; }
        }

        public DetectedApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappListResponse> IntuneDevicesDetectedappListAsync()
        {
            var p = new IntuneDevicesDetectedappListParameter();
            return await this.SendAsync<IntuneDevicesDetectedappListParameter, IntuneDevicesDetectedappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappListResponse> IntuneDevicesDetectedappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesDetectedappListParameter();
            return await this.SendAsync<IntuneDevicesDetectedappListParameter, IntuneDevicesDetectedappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappListResponse> IntuneDevicesDetectedappListAsync(IntuneDevicesDetectedappListParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesDetectedappListParameter, IntuneDevicesDetectedappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappListResponse> IntuneDevicesDetectedappListAsync(IntuneDevicesDetectedappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesDetectedappListParameter, IntuneDevicesDetectedappListResponse>(parameter, cancellationToken);
        }
    }
}
