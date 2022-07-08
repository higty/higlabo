using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListPermissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SitesId { get; set; }

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
            Id,
            GrantedToV2,
            GrantedToIdentitiesV2,
            Invitation,
            InheritedFrom,
            Link,
            Roles,
            ShareId,
            ExpirationDateTime,
            HasPassword,
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
    public partial class SiteListPermissionsResponse : RestApiResponse
    {
        public Permission[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync()
        {
            var p = new SiteListPermissionsParameter();
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListPermissionsParameter();
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync(SiteListPermissionsParameter parameter)
        {
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync(SiteListPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(parameter, cancellationToken);
        }
    }
}
