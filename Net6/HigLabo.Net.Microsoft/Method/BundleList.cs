using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BundleListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Drive_Bundles,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drive_Bundles: return $"/drive/bundles";
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
    }
    public partial class BundleListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bundle?view=graph-rest-1.0
        /// </summary>
        public partial class Bundle
        {
            public Int32? ChildCount { get; set; }
            public Album? Album { get; set; }
        }

        public Bundle[] Value { get; set; }
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
