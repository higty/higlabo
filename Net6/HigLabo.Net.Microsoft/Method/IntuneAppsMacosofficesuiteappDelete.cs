using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMacosofficesuiteappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsMacosofficesuiteappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappDeleteResponse> IntuneAppsMacosofficesuiteappDeleteAsync()
        {
            var p = new IntuneAppsMacosofficesuiteappDeleteParameter();
            return await this.SendAsync<IntuneAppsMacosofficesuiteappDeleteParameter, IntuneAppsMacosofficesuiteappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappDeleteResponse> IntuneAppsMacosofficesuiteappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMacosofficesuiteappDeleteParameter();
            return await this.SendAsync<IntuneAppsMacosofficesuiteappDeleteParameter, IntuneAppsMacosofficesuiteappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappDeleteResponse> IntuneAppsMacosofficesuiteappDeleteAsync(IntuneAppsMacosofficesuiteappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMacosofficesuiteappDeleteParameter, IntuneAppsMacosofficesuiteappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappDeleteResponse> IntuneAppsMacosofficesuiteappDeleteAsync(IntuneAppsMacosofficesuiteappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMacosofficesuiteappDeleteParameter, IntuneAppsMacosofficesuiteappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
