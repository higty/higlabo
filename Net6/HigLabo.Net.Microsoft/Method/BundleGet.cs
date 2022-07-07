using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BundleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            ChildCount,
            Album,
        }
        public enum ApiPath
        {
            Drive_Bundles_BundleId,
            Drive_Items_BundleId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drive_Bundles_BundleId: return $"/drive/bundles/{BundleId}";
                    case ApiPath.Drive_Items_BundleId: return $"/drive/items/{BundleId}";
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
        public string BundleId { get; set; }
    }
    public partial class BundleGetResponse : RestApiResponse
    {
        public Int32? ChildCount { get; set; }
        public Album? Album { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync()
        {
            var p = new BundleGetParameter();
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync(CancellationToken cancellationToken)
        {
            var p = new BundleGetParameter();
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync(BundleGetParameter parameter)
        {
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bundle-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BundleGetResponse> BundleGetAsync(BundleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BundleGetParameter, BundleGetResponse>(parameter, cancellationToken);
        }
    }
}
