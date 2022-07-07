using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappassignmentDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileAppId { get; set; }
        public string MobileAppAssignmentId { get; set; }
    }
    public partial class IntuneAppsMobileappassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentDeleteResponse> IntuneAppsMobileappassignmentDeleteAsync()
        {
            var p = new IntuneAppsMobileappassignmentDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentDeleteParameter, IntuneAppsMobileappassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentDeleteResponse> IntuneAppsMobileappassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappassignmentDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappassignmentDeleteParameter, IntuneAppsMobileappassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentDeleteResponse> IntuneAppsMobileappassignmentDeleteAsync(IntuneAppsMobileappassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentDeleteParameter, IntuneAppsMobileappassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappassignmentDeleteResponse> IntuneAppsMobileappassignmentDeleteAsync(IntuneAppsMobileappassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappassignmentDeleteParameter, IntuneAppsMobileappassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
