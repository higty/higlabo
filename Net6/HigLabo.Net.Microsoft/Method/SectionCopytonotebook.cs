using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectionCopytonotebookParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Onenote_Sections_Id_CopyToNotebook,
            Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToNotebook,
            Groups_Id_Onenote_Sections_Id_CopyToNotebook,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Sections_Id_CopyToNotebook: return $"/me/onenote/sections/{Id}/copyToNotebook";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToNotebook: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}/copyToNotebook";
                    case ApiPath.Groups_Id_Onenote_Sections_Id_CopyToNotebook: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}/copyToNotebook";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? GroupId { get; set; }
        public string? Id { get; set; }
        public string? RenameAs { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string SectionsId { get; set; }
    }
    public partial class SectionCopytonotebookResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytonotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytonotebookResponse> SectionCopytonotebookAsync()
        {
            var p = new SectionCopytonotebookParameter();
            return await this.SendAsync<SectionCopytonotebookParameter, SectionCopytonotebookResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytonotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytonotebookResponse> SectionCopytonotebookAsync(CancellationToken cancellationToken)
        {
            var p = new SectionCopytonotebookParameter();
            return await this.SendAsync<SectionCopytonotebookParameter, SectionCopytonotebookResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytonotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytonotebookResponse> SectionCopytonotebookAsync(SectionCopytonotebookParameter parameter)
        {
            return await this.SendAsync<SectionCopytonotebookParameter, SectionCopytonotebookResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytonotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytonotebookResponse> SectionCopytonotebookAsync(SectionCopytonotebookParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectionCopytonotebookParameter, SectionCopytonotebookResponse>(parameter, cancellationToken);
        }
    }
}
