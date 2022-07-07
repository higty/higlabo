using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.mobileLobApp/contentVersions";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.managedMobileLobApp/contentVersions";
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
    public partial class IntuneAppsMobileappcontentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileappcontent?view=graph-rest-1.0
        /// </summary>
        public partial class MobileAppContent
        {
            public string? Id { get; set; }
        }

        public MobileAppContent[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentListResponse> IntuneAppsMobileappcontentListAsync()
        {
            var p = new IntuneAppsMobileappcontentListParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentListParameter, IntuneAppsMobileappcontentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentListResponse> IntuneAppsMobileappcontentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentListParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentListParameter, IntuneAppsMobileappcontentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentListResponse> IntuneAppsMobileappcontentListAsync(IntuneAppsMobileappcontentListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentListParameter, IntuneAppsMobileappcontentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentListResponse> IntuneAppsMobileappcontentListAsync(IntuneAppsMobileappcontentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentListParameter, IntuneAppsMobileappcontentListResponse>(parameter, cancellationToken);
        }
    }
}
