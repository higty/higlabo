using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions_MobileAppContentId,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions_MobileAppContentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions/{MobileAppContentId}";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions_MobileAppContentId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.mobileLobApp/contentVersions/{MobileAppContentId}";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions_MobileAppContentId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.managedMobileLobApp/contentVersions/{MobileAppContentId}";
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
        public string MobileAppContentId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentGetResponse> IntuneAppsMobileappcontentGetAsync()
        {
            var p = new IntuneAppsMobileappcontentGetParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentGetParameter, IntuneAppsMobileappcontentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentGetResponse> IntuneAppsMobileappcontentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentGetParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentGetParameter, IntuneAppsMobileappcontentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentGetResponse> IntuneAppsMobileappcontentGetAsync(IntuneAppsMobileappcontentGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentGetParameter, IntuneAppsMobileappcontentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentGetResponse> IntuneAppsMobileappcontentGetAsync(IntuneAppsMobileappcontentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentGetParameter, IntuneAppsMobileappcontentGetResponse>(parameter, cancellationToken);
        }
    }
}
