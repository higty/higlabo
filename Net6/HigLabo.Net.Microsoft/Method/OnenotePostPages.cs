using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenotePostPagesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Pages: return $"/me/onenote/pages";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages: return $"/users/{IdOrUserPrincipalName}/onenote/pages";
                    case ApiPath.Groups_Id_Onenote_Pages: return $"/groups/{Id}/onenote/pages";
                    case ApiPath.Sites_Id_Onenote_Pages: return $"/sites/{Id}/onenote/pages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Onenote_Pages,
            Users_IdOrUserPrincipalName_Onenote_Pages,
            Groups_Id_Onenote_Pages,
            Sites_Id_Onenote_Pages,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Stream? Content { get; set; }
        public string? ContentUrl { get; set; }
        public string? CreatedByAppId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Level { get; set; }
        public PageLinks? Links { get; set; }
        public Int32? Order { get; set; }
        public string? Self { get; set; }
        public string? Title { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public Section? ParentSection { get; set; }
    }
    public partial class OnenotePostPagesResponse : RestApiResponse
    {
        public Stream? Content { get; set; }
        public string? ContentUrl { get; set; }
        public string? CreatedByAppId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Level { get; set; }
        public PageLinks? Links { get; set; }
        public Int32? Order { get; set; }
        public string? Self { get; set; }
        public string? Title { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public Section? ParentSection { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostPagesResponse> OnenotePostPagesAsync()
        {
            var p = new OnenotePostPagesParameter();
            return await this.SendAsync<OnenotePostPagesParameter, OnenotePostPagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostPagesResponse> OnenotePostPagesAsync(CancellationToken cancellationToken)
        {
            var p = new OnenotePostPagesParameter();
            return await this.SendAsync<OnenotePostPagesParameter, OnenotePostPagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostPagesResponse> OnenotePostPagesAsync(OnenotePostPagesParameter parameter)
        {
            return await this.SendAsync<OnenotePostPagesParameter, OnenotePostPagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostPagesResponse> OnenotePostPagesAsync(OnenotePostPagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnenotePostPagesParameter, OnenotePostPagesResponse>(parameter, cancellationToken);
        }
    }
}
