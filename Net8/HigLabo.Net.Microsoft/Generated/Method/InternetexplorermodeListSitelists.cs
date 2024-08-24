using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-list-sitelists?view=graph-rest-1.0
    /// </summary>
    public partial class InternetexplorermodeListSitelistsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists: return $"/admin/edge/internetExplorerMode/siteLists";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_Edge_InternetExplorerMode_SiteLists,
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
    public partial class InternetexplorermodeListSitelistsResponse : RestApiResponse<BrowserSiteList>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-list-sitelists?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-list-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodeListSitelistsResponse> InternetexplorermodeListSitelistsAsync()
        {
            var p = new InternetexplorermodeListSitelistsParameter();
            return await this.SendAsync<InternetexplorermodeListSitelistsParameter, InternetexplorermodeListSitelistsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-list-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodeListSitelistsResponse> InternetexplorermodeListSitelistsAsync(CancellationToken cancellationToken)
        {
            var p = new InternetexplorermodeListSitelistsParameter();
            return await this.SendAsync<InternetexplorermodeListSitelistsParameter, InternetexplorermodeListSitelistsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-list-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodeListSitelistsResponse> InternetexplorermodeListSitelistsAsync(InternetexplorermodeListSitelistsParameter parameter)
        {
            return await this.SendAsync<InternetexplorermodeListSitelistsParameter, InternetexplorermodeListSitelistsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-list-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodeListSitelistsResponse> InternetexplorermodeListSitelistsAsync(InternetexplorermodeListSitelistsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InternetexplorermodeListSitelistsParameter, InternetexplorermodeListSitelistsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-list-sitelists?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<BrowserSiteList> InternetexplorermodeListSitelistsEnumerateAsync(InternetexplorermodeListSitelistsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<InternetexplorermodeListSitelistsParameter, InternetexplorermodeListSitelistsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<BrowserSiteList>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
