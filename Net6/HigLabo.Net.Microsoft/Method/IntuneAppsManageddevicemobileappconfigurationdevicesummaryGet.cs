using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatusSummary,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatusSummary: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/deviceStatusSummary";
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
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? PendingCount { get; set; }
        public Int32? NotApplicableCount { get; set; }
        public Int32? SuccessCount { get; set; }
        public Int32? ErrorCount { get; set; }
        public Int32? FailedCount { get; set; }
        public DateTimeOffset? LastUpdateDateTime { get; set; }
        public Int32? ConfigurationVersion { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetAsync(IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetAsync(IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicesummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
