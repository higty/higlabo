using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-update?view=graph-rest-1.0
    /// </summary>
    public partial class PageUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? PagesId { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Pages_Id_Content: return $"/me/onenote/pages/{Id}/content";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages_Id_Content: return $"/users/{IdOrUserPrincipalName}/onenote/pages/{Id}/content";
                    case ApiPath.Groups_Id_Onenote_Pages_Id_Content: return $"/groups/{GroupsId}/onenote/pages/{PagesId}/content";
                    case ApiPath.Sites_Id_Onenote_Pages_Id_Content: return $"/sites/{SitesId}/onenote/pages/{PagesId}/content";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Onenote_Pages_Id_Content,
            Users_IdOrUserPrincipalName_Onenote_Pages_Id_Content,
            Groups_Id_Onenote_Pages_Id_Content,
            Sites_Id_Onenote_Pages_Id_Content,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class PageUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PageUpdateResponse> PageUpdateAsync()
        {
            var p = new PageUpdateParameter();
            return await this.SendAsync<PageUpdateParameter, PageUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PageUpdateResponse> PageUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PageUpdateParameter();
            return await this.SendAsync<PageUpdateParameter, PageUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PageUpdateResponse> PageUpdateAsync(PageUpdateParameter parameter)
        {
            return await this.SendAsync<PageUpdateParameter, PageUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PageUpdateResponse> PageUpdateAsync(PageUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PageUpdateParameter, PageUpdateResponse>(parameter, cancellationToken);
        }
    }
}
