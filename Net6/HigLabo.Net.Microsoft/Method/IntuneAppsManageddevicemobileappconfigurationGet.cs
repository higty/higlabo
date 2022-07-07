using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}";
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
    public partial class IntuneAppsManageddevicemobileappconfigurationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public String[]? TargetedMobileApps { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationGetResponse> IntuneAppsManageddevicemobileappconfigurationGetAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationGetParameter, IntuneAppsManageddevicemobileappconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationGetResponse> IntuneAppsManageddevicemobileappconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationGetParameter, IntuneAppsManageddevicemobileappconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationGetResponse> IntuneAppsManageddevicemobileappconfigurationGetAsync(IntuneAppsManageddevicemobileappconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationGetParameter, IntuneAppsManageddevicemobileappconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationGetResponse> IntuneAppsManageddevicemobileappconfigurationGetAsync(IntuneAppsManageddevicemobileappconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationGetParameter, IntuneAppsManageddevicemobileappconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
