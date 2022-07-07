using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_Assignments: return $"/deviceAppManagement/mobileApps/{MobileAppId}/assignments";
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
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsMobileappassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileappassignment?view=graph-rest-1.0
        /// </summary>
        public partial class MobileAppAssignment
        {
            public enum MobileAppAssignmentInstallIntent
            {
                Available,
                Required,
                Uninstall,
                AvailableWithoutEnrollment,
            }

            public string? Id { get; set; }
            public InstallIntent? Intent { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
            public MobileAppAssignmentSettings? Settings { get; set; }
        }

        public MobileAppAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentListResponse> IntuneAppsMobileappassignmentListAsync()
        {
            var p = new IntuneAppsMobileappassignmentListParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentListParameter, IntuneAppsMobileappassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentListResponse> IntuneAppsMobileappassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappassignmentListParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentListParameter, IntuneAppsMobileappassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentListResponse> IntuneAppsMobileappassignmentListAsync(IntuneAppsMobileappassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentListParameter, IntuneAppsMobileappassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentListResponse> IntuneAppsMobileappassignmentListAsync(IntuneAppsMobileappassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentListParameter, IntuneAppsMobileappassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
