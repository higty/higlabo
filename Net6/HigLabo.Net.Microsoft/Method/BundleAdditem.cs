using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BundleAdditemParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Drive_Bundles_BundleId_Children,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drive_Bundles_BundleId_Children: return $"/drive/bundles/{BundleId}/children";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string BundleId { get; set; }
    }
    public partial class BundleAdditemResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleAdditemResponse> BundleAdditemAsync()
        {
            var p = new BundleAdditemParameter();
            return await this.SendAsync<BundleAdditemParameter, BundleAdditemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleAdditemResponse> BundleAdditemAsync(CancellationToken cancellationToken)
        {
            var p = new BundleAdditemParameter();
            return await this.SendAsync<BundleAdditemParameter, BundleAdditemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleAdditemResponse> BundleAdditemAsync(BundleAdditemParameter parameter)
        {
            return await this.SendAsync<BundleAdditemParameter, BundleAdditemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleAdditemResponse> BundleAdditemAsync(BundleAdditemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BundleAdditemParameter, BundleAdditemResponse>(parameter, cancellationToken);
        }
    }
}
