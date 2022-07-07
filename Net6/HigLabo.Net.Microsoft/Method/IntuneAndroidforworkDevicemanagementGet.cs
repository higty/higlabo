using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAndroidforworkDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement: return $"/deviceManagement";
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
    public partial class IntuneAndroidforworkDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-androidforwork-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAndroidforworkDevicemanagementGetResponse> IntuneAndroidforworkDevicemanagementGetAsync()
        {
            var p = new IntuneAndroidforworkDevicemanagementGetParameter();
            return await this.SendAsync<IntuneAndroidforworkDevicemanagementGetParameter, IntuneAndroidforworkDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-androidforwork-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAndroidforworkDevicemanagementGetResponse> IntuneAndroidforworkDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAndroidforworkDevicemanagementGetParameter();
            return await this.SendAsync<IntuneAndroidforworkDevicemanagementGetParameter, IntuneAndroidforworkDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-androidforwork-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAndroidforworkDevicemanagementGetResponse> IntuneAndroidforworkDevicemanagementGetAsync(IntuneAndroidforworkDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneAndroidforworkDevicemanagementGetParameter, IntuneAndroidforworkDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-androidforwork-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAndroidforworkDevicemanagementGetResponse> IntuneAndroidforworkDevicemanagementGetAsync(IntuneAndroidforworkDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAndroidforworkDevicemanagementGetParameter, IntuneAndroidforworkDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
