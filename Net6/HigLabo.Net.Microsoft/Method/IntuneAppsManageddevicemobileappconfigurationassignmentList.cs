using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/assignments";
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
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-manageddevicemobileappconfigurationassignment?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedDeviceMobileAppConfigurationAssignment
        {
            public string? Id { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        }

        public ManagedDeviceMobileAppConfigurationAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentListResponse> IntuneAppsManageddevicemobileappconfigurationassignmentListAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentListParameter, IntuneAppsManageddevicemobileappconfigurationassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentListResponse> IntuneAppsManageddevicemobileappconfigurationassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentListParameter, IntuneAppsManageddevicemobileappconfigurationassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentListResponse> IntuneAppsManageddevicemobileappconfigurationassignmentListAsync(IntuneAppsManageddevicemobileappconfigurationassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentListParameter, IntuneAppsManageddevicemobileappconfigurationassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentListResponse> IntuneAppsManageddevicemobileappconfigurationassignmentListAsync(IntuneAppsManageddevicemobileappconfigurationassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentListParameter, IntuneAppsManageddevicemobileappconfigurationassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
