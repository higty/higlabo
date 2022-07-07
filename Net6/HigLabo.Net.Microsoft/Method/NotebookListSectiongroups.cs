using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NotebookListSectiongroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_Notebooks_Id_SectionGroups,
            Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_SectionGroups,
            Groups_Id_Onenote_Notebooks_Id_SectionGroups,
            Sites_Id_Onenote_Notebooks_Id_SectionGroups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Notebooks_Id_SectionGroups: return $"/me/onenote/notebooks/{Id}/sectionGroups";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_SectionGroups: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/{Id}/sectionGroups";
                    case ApiPath.Groups_Id_Onenote_Notebooks_Id_SectionGroups: return $"/groups/{GroupsId}/onenote/notebooks/{NotebooksId}/sectionGroups";
                    case ApiPath.Sites_Id_Onenote_Notebooks_Id_SectionGroups: return $"/sites/{SitesId}/onenote/notebooks/{NotebooksId}/sectionGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string NotebooksId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class NotebookListSectiongroupsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/sectiongroup?view=graph-rest-1.0
        /// </summary>
        public partial class SectionGroup
        {
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public string? SectionGroupsUrl { get; set; }
            public string? SectionsUrl { get; set; }
            public string? Self { get; set; }
        }

        public SectionGroup[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookListSectiongroupsResponse> NotebookListSectiongroupsAsync()
        {
            var p = new NotebookListSectiongroupsParameter();
            return await this.SendAsync<NotebookListSectiongroupsParameter, NotebookListSectiongroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookListSectiongroupsResponse> NotebookListSectiongroupsAsync(CancellationToken cancellationToken)
        {
            var p = new NotebookListSectiongroupsParameter();
            return await this.SendAsync<NotebookListSectiongroupsParameter, NotebookListSectiongroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookListSectiongroupsResponse> NotebookListSectiongroupsAsync(NotebookListSectiongroupsParameter parameter)
        {
            return await this.SendAsync<NotebookListSectiongroupsParameter, NotebookListSectiongroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookListSectiongroupsResponse> NotebookListSectiongroupsAsync(NotebookListSectiongroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NotebookListSectiongroupsParameter, NotebookListSectiongroupsResponse>(parameter, cancellationToken);
        }
    }
}
