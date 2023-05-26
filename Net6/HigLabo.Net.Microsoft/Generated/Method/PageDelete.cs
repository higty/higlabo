using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
    /// </summary>
    public partial class PageDeleteParameter : IRestApiParameter
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
                    case ApiPath.Me_Onenote_Pages_Id: return $"/me/onenote/pages/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages_Id: return $"/users/{IdOrUserPrincipalName}/onenote/pages/{Id}";
                    case ApiPath.Groups_Id_Onenote_Pages_Id: return $"/groups/{GroupsId}/onenote/pages/{PagesId}";
                    case ApiPath.Sites_Id_Onenote_Pages_Id: return $"/sites/{SitesId}/onenote/pages/{PagesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Onenote_Pages_Id,
            Users_IdOrUserPrincipalName_Onenote_Pages_Id,
            Groups_Id_Onenote_Pages_Id,
            Sites_Id_Onenote_Pages_Id,
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
    public partial class PageDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync()
        {
            var p = new PageDeleteParameter();
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PageDeleteParameter();
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync(PageDeleteParameter parameter)
        {
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync(PageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(parameter, cancellationToken);
        }
    }
}
