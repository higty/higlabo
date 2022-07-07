using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappassignmentCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsMobileappassignmentCreateParameterInstallIntent
        {
            Available,
            Required,
            Uninstall,
            AvailableWithoutEnrollment,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public IntuneAppsMobileappassignmentCreateParameterInstallIntent Intent { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public MobileAppAssignmentSettings? Settings { get; set; }
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsMobileappassignmentCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentCreateResponse> IntuneAppsMobileappassignmentCreateAsync()
        {
            var p = new IntuneAppsMobileappassignmentCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentCreateParameter, IntuneAppsMobileappassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentCreateResponse> IntuneAppsMobileappassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappassignmentCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentCreateParameter, IntuneAppsMobileappassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentCreateResponse> IntuneAppsMobileappassignmentCreateAsync(IntuneAppsMobileappassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentCreateParameter, IntuneAppsMobileappassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentCreateResponse> IntuneAppsMobileappassignmentCreateAsync(IntuneAppsMobileappassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentCreateParameter, IntuneAppsMobileappassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
