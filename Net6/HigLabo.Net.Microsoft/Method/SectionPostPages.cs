using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectionPostPagesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Onenote_Sections_Id_Pages,
            Users_IdOrUserPrincipalName_Onenote_Sections_Id_Pages,
            Groups_Id_Onenote_Sections_Id_Pages,
            Sites_Id_Onenote_Sections_Id_Pages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Sections_Id_Pages: return $"/me/onenote/sections/{Id}/pages";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id_Pages: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}/pages";
                    case ApiPath.Groups_Id_Onenote_Sections_Id_Pages: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}/pages";
                    case ApiPath.Sites_Id_Onenote_Sections_Id_Pages: return $"/sites/{SitesId}/onenote/sections/{SectionsId}/pages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string SectionsId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class SectionPostPagesResponse : RestApiResponse
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionPostPagesResponse> SectionPostPagesAsync()
        {
            var p = new SectionPostPagesParameter();
            return await this.SendAsync<SectionPostPagesParameter, SectionPostPagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionPostPagesResponse> SectionPostPagesAsync(CancellationToken cancellationToken)
        {
            var p = new SectionPostPagesParameter();
            return await this.SendAsync<SectionPostPagesParameter, SectionPostPagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionPostPagesResponse> SectionPostPagesAsync(SectionPostPagesParameter parameter)
        {
            return await this.SendAsync<SectionPostPagesParameter, SectionPostPagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-post-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionPostPagesResponse> SectionPostPagesAsync(SectionPostPagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectionPostPagesParameter, SectionPostPagesResponse>(parameter, cancellationToken);
        }
    }
}
