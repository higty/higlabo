using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-removeitem?view=graph-rest-1.0
    /// </summary>
    public partial class BundleRemoveitemParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BundleId { get; set; }
            public string? ItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drive_Bundles_BundleId_Children_ItemId: return $"/drive/bundles/{BundleId}/children/{ItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drive_Bundles_BundleId_Children_ItemId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class BundleRemoveitemResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-removeitem?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-removeitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BundleRemoveitemResponse> BundleRemoveitemAsync()
        {
            var p = new BundleRemoveitemParameter();
            return await this.SendAsync<BundleRemoveitemParameter, BundleRemoveitemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-removeitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BundleRemoveitemResponse> BundleRemoveitemAsync(CancellationToken cancellationToken)
        {
            var p = new BundleRemoveitemParameter();
            return await this.SendAsync<BundleRemoveitemParameter, BundleRemoveitemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-removeitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BundleRemoveitemResponse> BundleRemoveitemAsync(BundleRemoveitemParameter parameter)
        {
            return await this.SendAsync<BundleRemoveitemParameter, BundleRemoveitemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-removeitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BundleRemoveitemResponse> BundleRemoveitemAsync(BundleRemoveitemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BundleRemoveitemParameter, BundleRemoveitemResponse>(parameter, cancellationToken);
        }
    }
}
