using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-post-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public partial class NotebookPostSectionGroupsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? NotebooksId { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Notebooks_Id_SectionGroups: return $"/me/onenote/notebooks/{Id}/sectionGroups";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_SectionGroups: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/{Id}/sectionGroups";
                    case ApiPath.Groups_Id_Onenote_Notebooks_Id_SectionGroups: return $"/groups/{GroupsId}/onenote/notebooks/{NotebooksId}/sectionGroups";
                    case ApiPath.Sites_Id_Onenote_Notebooks_Id_SectionGroups: return $"/sites/{SitesId}/onenote/notebooks/{NotebooksId}/sectionGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Onenote_Notebooks_Id_SectionGroups,
            Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_SectionGroups,
            Groups_Id_Onenote_Notebooks_Id_SectionGroups,
            Sites_Id_Onenote_Notebooks_Id_SectionGroups,
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
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? SectionGroupsUrl { get; set; }
        public string? SectionsUrl { get; set; }
        public string? Self { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public SectionGroup? ParentSectionGroup { get; set; }
        public SectionGroup[]? SectionGroups { get; set; }
        public Section[]? Sections { get; set; }
    }
    public partial class NotebookPostSectionGroupsResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? SectionGroupsUrl { get; set; }
        public string? SectionsUrl { get; set; }
        public string? Self { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public SectionGroup? ParentSectionGroup { get; set; }
        public SectionGroup[]? SectionGroups { get; set; }
        public Section[]? Sections { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-post-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-post-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookPostSectionGroupsResponse> NotebookPostSectionGroupsAsync()
        {
            var p = new NotebookPostSectionGroupsParameter();
            return await this.SendAsync<NotebookPostSectionGroupsParameter, NotebookPostSectionGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-post-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookPostSectionGroupsResponse> NotebookPostSectionGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new NotebookPostSectionGroupsParameter();
            return await this.SendAsync<NotebookPostSectionGroupsParameter, NotebookPostSectionGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-post-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookPostSectionGroupsResponse> NotebookPostSectionGroupsAsync(NotebookPostSectionGroupsParameter parameter)
        {
            return await this.SendAsync<NotebookPostSectionGroupsParameter, NotebookPostSectionGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-post-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookPostSectionGroupsResponse> NotebookPostSectionGroupsAsync(NotebookPostSectionGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NotebookPostSectionGroupsParameter, NotebookPostSectionGroupsResponse>(parameter, cancellationToken);
        }
    }
}
