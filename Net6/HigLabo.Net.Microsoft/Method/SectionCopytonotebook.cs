using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectionCopytonotebookParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string GroupsId { get; set; }
            public string SectionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Sections_Id_CopyToNotebook: return $"/me/onenote/sections/{Id}/copyToNotebook";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToNotebook: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}/copyToNotebook";
                    case ApiPath.Groups_Id_Onenote_Sections_Id_CopyToNotebook: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}/copyToNotebook";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Onenote_Sections_Id_CopyToNotebook,
            Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToNotebook,
            Groups_Id_Onenote_Sections_Id_CopyToNotebook,
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
        public string? GroupId { get; set; }
        public string? Id { get; set; }
        public string? RenameAs { get; set; }
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
