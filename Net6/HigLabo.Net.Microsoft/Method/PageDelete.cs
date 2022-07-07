using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PageDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Onenote_Pages_Id,
            Users_IdOrUserPrincipalName_Onenote_Pages_Id,
            Groups_Id_Onenote_Pages_Id,
            Sites_Id_Onenote_Pages_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Pages_Id: return $"/me/onenote/pages/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages_Id: return $"/users/{IdOrUserPrincipalName}/onenote/pages/{Id}";
                    case ApiPath.Groups_Id_Onenote_Pages_Id: return $"/groups/{GroupsId}/onenote/pages/{PagesId}";
                    case ApiPath.Sites_Id_Onenote_Pages_Id: return $"/sites/{SitesId}/onenote/pages/{PagesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string PagesId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class PageDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync()
        {
            var p = new PageDeleteParameter();
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PageDeleteParameter();
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync(PageDeleteParameter parameter)
        {
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PageDeleteResponse> PageDeleteAsync(PageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PageDeleteParameter, PageDeleteResponse>(parameter, cancellationToken);
        }
    }
}
