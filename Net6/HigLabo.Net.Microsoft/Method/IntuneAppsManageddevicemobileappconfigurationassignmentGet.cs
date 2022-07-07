using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments_ManagedDeviceMobileAppConfigurationAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments_ManagedDeviceMobileAppConfigurationAssignmentId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/assignments/{ManagedDeviceMobileAppConfigurationAssignmentId}";
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
        public string ManagedDeviceMobileAppConfigurationAssignmentId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse> IntuneAppsManageddevicemobileappconfigurationassignmentGetAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter, IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse> IntuneAppsManageddevicemobileappconfigurationassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter, IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse> IntuneAppsManageddevicemobileappconfigurationassignmentGetAsync(IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter, IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse> IntuneAppsManageddevicemobileappconfigurationassignmentGetAsync(IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentGetParameter, IntuneAppsManageddevicemobileappconfigurationassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
