using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resource-get?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? ResourcesId { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Resources_Id_Content: return $"/me/onenote/resources/{Id}/content";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Resources_Id_Content: return $"/users/{IdOrUserPrincipalName}/onenote/resources/{Id}/content";
                    case ApiPath.Groups_Id_Onenote_Resources_Id_Content: return $"/groups/{GroupsId}/onenote/resources/{ResourcesId}/content";
                    case ApiPath.Sites_Id_Onenote_Resources_Id_Content: return $"/sites/{SitesId}/onenote/resources/{ResourcesId}/content";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_Resources_Id_Content,
            Users_IdOrUserPrincipalName_Onenote_Resources_Id_Content,
            Groups_Id_Onenote_Resources_Id_Content,
            Sites_Id_Onenote_Resources_Id_Content,
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
    public partial class ResourceGetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resource-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/resource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ResourceGetResponse> ResourceGetAsync()
        {
            var p = new ResourceGetParameter();
            return await this.SendAsync<ResourceGetParameter, ResourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/resource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ResourceGetResponse> ResourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new ResourceGetParameter();
            return await this.SendAsync<ResourceGetParameter, ResourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/resource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ResourceGetResponse> ResourceGetAsync(ResourceGetParameter parameter)
        {
            return await this.SendAsync<ResourceGetParameter, ResourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/resource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ResourceGetResponse> ResourceGetAsync(ResourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ResourceGetParameter, ResourceGetResponse>(parameter, cancellationToken);
        }
    }
}
