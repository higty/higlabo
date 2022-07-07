using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations: return $"/deviceAppManagement/mobileAppConfigurations";
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
    public partial class IntuneAppsManageddevicemobileappconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-manageddevicemobileappconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedDeviceMobileAppConfiguration
        {
            public string? Id { get; set; }
            public String[]? TargetedMobileApps { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
        }

        public ManagedDeviceMobileAppConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationListResponse> IntuneAppsManageddevicemobileappconfigurationListAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationListParameter, IntuneAppsManageddevicemobileappconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationListResponse> IntuneAppsManageddevicemobileappconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationListParameter, IntuneAppsManageddevicemobileappconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationListResponse> IntuneAppsManageddevicemobileappconfigurationListAsync(IntuneAppsManageddevicemobileappconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationListParameter, IntuneAppsManageddevicemobileappconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationListResponse> IntuneAppsManageddevicemobileappconfigurationListAsync(IntuneAppsManageddevicemobileappconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationListParameter, IntuneAppsManageddevicemobileappconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
