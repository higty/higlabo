using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesDetectedappGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DetectedApps_DetectedAppId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId: return $"/deviceManagement/detectedApps/{DetectedAppId}";
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
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesDetectedappGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappGetResponse> IntuneDevicesDetectedappGetAsync()
        {
            var p = new IntuneDevicesDetectedappGetParameter();
            return await this.SendAsync<IntuneDevicesDetectedappGetParameter, IntuneDevicesDetectedappGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappGetResponse> IntuneDevicesDetectedappGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesDetectedappGetParameter();
            return await this.SendAsync<IntuneDevicesDetectedappGetParameter, IntuneDevicesDetectedappGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappGetResponse> IntuneDevicesDetectedappGetAsync(IntuneDevicesDetectedappGetParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesDetectedappGetParameter, IntuneDevicesDetectedappGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappGetResponse> IntuneDevicesDetectedappGetAsync(IntuneDevicesDetectedappGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesDetectedappGetParameter, IntuneDevicesDetectedappGetResponse>(parameter, cancellationToken);
        }
    }
}
