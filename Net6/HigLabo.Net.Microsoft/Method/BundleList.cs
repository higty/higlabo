using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BundleListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drive_Bundles: return $"/drive/bundles";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ChildCount,
            Album,
        }
        public enum ApiPath
        {
            Drive_Bundles,
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
    public partial class BundleListResponse : RestApiResponse
    {
        public Bundle[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleListResponse> BundleListAsync()
        {
            var p = new BundleListParameter();
            return await this.SendAsync<BundleListParameter, BundleListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleListResponse> BundleListAsync(CancellationToken cancellationToken)
        {
            var p = new BundleListParameter();
            return await this.SendAsync<BundleListParameter, BundleListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleListResponse> BundleListAsync(BundleListParameter parameter)
        {
            return await this.SendAsync<BundleListParameter, BundleListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleListResponse> BundleListAsync(BundleListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BundleListParameter, BundleListResponse>(parameter, cancellationToken);
        }
    }
}
