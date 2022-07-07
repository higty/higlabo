using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMicrosoftstoreforbusinessappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsMicrosoftstoreforbusinessappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappDeleteResponse> IntuneAppsMicrosoftstoreforbusinessappDeleteAsync()
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappDeleteParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappDeleteParameter, IntuneAppsMicrosoftstoreforbusinessappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappDeleteResponse> IntuneAppsMicrosoftstoreforbusinessappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappDeleteParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappDeleteParameter, IntuneAppsMicrosoftstoreforbusinessappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappDeleteResponse> IntuneAppsMicrosoftstoreforbusinessappDeleteAsync(IntuneAppsMicrosoftstoreforbusinessappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappDeleteParameter, IntuneAppsMicrosoftstoreforbusinessappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappDeleteResponse> IntuneAppsMicrosoftstoreforbusinessappDeleteAsync(IntuneAppsMicrosoftstoreforbusinessappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappDeleteParameter, IntuneAppsMicrosoftstoreforbusinessappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
