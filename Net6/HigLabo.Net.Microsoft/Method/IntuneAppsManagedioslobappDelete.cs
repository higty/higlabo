using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedioslobappDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId: return $"/deviceAppManagement/mobileApps/{MobileAppId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsManagedioslobappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedioslobappDeleteResponse> IntuneAppsManagedioslobappDeleteAsync()
        {
            var p = new IntuneAppsManagedioslobappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagedioslobappDeleteParameter, IntuneAppsManagedioslobappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedioslobappDeleteResponse> IntuneAppsManagedioslobappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedioslobappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagedioslobappDeleteParameter, IntuneAppsManagedioslobappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedioslobappDeleteResponse> IntuneAppsManagedioslobappDeleteAsync(IntuneAppsManagedioslobappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedioslobappDeleteParameter, IntuneAppsManagedioslobappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedioslobappDeleteResponse> IntuneAppsManagedioslobappDeleteAsync(IntuneAppsManagedioslobappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedioslobappDeleteParameter, IntuneAppsManagedioslobappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
