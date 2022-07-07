using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectionCopytosectiongroupParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Onenote_Sections_Id_CopyToSectionGroup,
            Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToSectionGroup,
            Groups_Id_Onenote_Sections_Id_CopyToSectionGroup,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Sections_Id_CopyToSectionGroup: return $"/me/onenote/sections/{Id}/copyToSectionGroup";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToSectionGroup: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}/copyToSectionGroup";
                    case ApiPath.Groups_Id_Onenote_Sections_Id_CopyToSectionGroup: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}/copyToSectionGroup";
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
    public partial class SectionCopytosectiongroupResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytosectiongroupResponse> SectionCopytosectiongroupAsync()
        {
            var p = new SectionCopytosectiongroupParameter();
            return await this.SendAsync<SectionCopytosectiongroupParameter, SectionCopytosectiongroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytosectiongroupResponse> SectionCopytosectiongroupAsync(CancellationToken cancellationToken)
        {
            var p = new SectionCopytosectiongroupParameter();
            return await this.SendAsync<SectionCopytosectiongroupParameter, SectionCopytosectiongroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytosectiongroupResponse> SectionCopytosectiongroupAsync(SectionCopytosectiongroupParameter parameter)
        {
            return await this.SendAsync<SectionCopytosectiongroupParameter, SectionCopytosectiongroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionCopytosectiongroupResponse> SectionCopytosectiongroupAsync(SectionCopytosectiongroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectionCopytosectiongroupParameter, SectionCopytosectiongroupResponse>(parameter, cancellationToken);
        }
    }
}
