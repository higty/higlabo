using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
    /// </summary>
    public partial class SiteListPermissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SitesId_Permissions: return $"/sites/{SitesId}/permissions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SitesId_Permissions,
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
    public partial class SiteListPermissionsResponse : RestApiResponse<Permission>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListPermissionsResponse> SiteListPermissionsAsync()
        {
            var p = new SiteListPermissionsParameter();
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListPermissionsResponse> SiteListPermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListPermissionsParameter();
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListPermissionsResponse> SiteListPermissionsAsync(SiteListPermissionsParameter parameter)
        {
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListPermissionsResponse> SiteListPermissionsAsync(SiteListPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Permission> SiteListPermissionsEnumerateAsync(SiteListPermissionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Permission>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
