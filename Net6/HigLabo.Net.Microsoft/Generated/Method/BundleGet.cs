using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
    /// </summary>
    public partial class BundleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BundleId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drive_Bundles_BundleId: return $"/drive/bundles/{BundleId}";
                    case ApiPath.Drive_Items_BundleId: return $"/drive/items/{BundleId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Album,
            ChildCount,
        }
        public enum ApiPath
        {
            Drive_Bundles_BundleId,
            Drive_Items_BundleId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class BundleGetResponse : RestApiResponse
    {
        public Album? Album { get; set; }
        public Int32? ChildCount { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync()
        {
            var p = new BundleGetParameter();
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync(CancellationToken cancellationToken)
        {
            var p = new BundleGetParameter();
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync(BundleGetParameter parameter)
        {
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync(BundleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(parameter, cancellationToken);
        }
    }
}
