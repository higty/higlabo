using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_SoftwareUpdateStatusSummary,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_SoftwareUpdateStatusSummary: return $"/deviceManagement/softwareUpdateStatusSummary";
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
    public partial class IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public Int32? CompliantDeviceCount { get; set; }
        public Int32? NonCompliantDeviceCount { get; set; }
        public Int32? RemediatedDeviceCount { get; set; }
        public Int32? ErrorDeviceCount { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? ConflictDeviceCount { get; set; }
        public Int32? NotApplicableDeviceCount { get; set; }
        public Int32? CompliantUserCount { get; set; }
        public Int32? NonCompliantUserCount { get; set; }
        public Int32? RemediatedUserCount { get; set; }
        public Int32? ErrorUserCount { get; set; }
        public Int32? UnknownUserCount { get; set; }
        public Int32? ConflictUserCount { get; set; }
        public Int32? NotApplicableUserCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-softwareupdatestatussummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse> IntuneDeviceconfigSoftwareupdatestatussummaryGetAsync()
        {
            var p = new IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter, IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-softwareupdatestatussummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse> IntuneDeviceconfigSoftwareupdatestatussummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter, IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-softwareupdatestatussummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse> IntuneDeviceconfigSoftwareupdatestatussummaryGetAsync(IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter, IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-softwareupdatestatussummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse> IntuneDeviceconfigSoftwareupdatestatussummaryGetAsync(IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSoftwareupdatestatussummaryGetParameter, IntuneDeviceconfigSoftwareupdatestatussummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
