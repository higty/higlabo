using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_Assignments_MobileAppAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_Assignments_MobileAppAssignmentId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/assignments/{MobileAppAssignmentId}";
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
        public string MobileAppAssignmentId { get; set; }
    }
    public partial class IntuneAppsMobileappassignmentGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentGetResponse> IntuneAppsMobileappassignmentGetAsync()
        {
            var p = new IntuneAppsMobileappassignmentGetParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentGetParameter, IntuneAppsMobileappassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentGetResponse> IntuneAppsMobileappassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappassignmentGetParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentGetParameter, IntuneAppsMobileappassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentGetResponse> IntuneAppsMobileappassignmentGetAsync(IntuneAppsMobileappassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentGetParameter, IntuneAppsMobileappassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentGetResponse> IntuneAppsMobileappassignmentGetAsync(IntuneAppsMobileappassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentGetParameter, IntuneAppsMobileappassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
