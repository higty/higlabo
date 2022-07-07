using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_Assign: return $"/deviceAppManagement/mobileApps/{MobileAppId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public MobileAppAssignment[]? MobileAppAssignments { get; set; }
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsMobileappAssignResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappAssignResponse> IntuneAppsMobileappAssignAsync()
        {
            var p = new IntuneAppsMobileappAssignParameter();
            return await this.SendAsync<IntuneAppsMobileappAssignParameter, IntuneAppsMobileappAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappAssignResponse> IntuneAppsMobileappAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappAssignParameter();
            return await this.SendAsync<IntuneAppsMobileappAssignParameter, IntuneAppsMobileappAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappAssignResponse> IntuneAppsMobileappAssignAsync(IntuneAppsMobileappAssignParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappAssignParameter, IntuneAppsMobileappAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappAssignResponse> IntuneAppsMobileappAssignAsync(IntuneAppsMobileappAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappAssignParameter, IntuneAppsMobileappAssignResponse>(parameter, cancellationToken);
        }
    }
}
