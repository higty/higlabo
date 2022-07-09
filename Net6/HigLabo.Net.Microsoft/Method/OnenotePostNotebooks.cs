using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenotePostNotebooksParameter : IRestApiParameter
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
                    case ApiPath.Me_Onenote_Notebooks: return $"/me/onenote/notebooks";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks";
                    case ApiPath.Groups_Id_Onenote_Notebooks: return $"/groups/{Id}/onenote/notebooks";
                    case ApiPath.Sites_Id_Onenote_Notebooks: return $"/sites/{Id}/onenote/notebooks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum NotebookOnenoteUserRole
        {
            Owner,
            Contributor,
            Reader,
            None,
        }
        public enum ApiPath
        {
            Me_Onenote_Notebooks,
            Users_IdOrUserPrincipalName_Onenote_Notebooks,
            Groups_Id_Onenote_Notebooks,
            Sites_Id_Onenote_Notebooks,
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
        public string? Id { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsShared { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public NotebookLinks? Links { get; set; }
        public string? DisplayName { get; set; }
        public string? SectionGroupsUrl { get; set; }
        public string? SectionsUrl { get; set; }
        public string? Self { get; set; }
        public NotebookOnenoteUserRole UserRole { get; set; }
        public SectionGroup[]? SectionGroups { get; set; }
        public Section[]? Sections { get; set; }
    }
    public partial class OnenotePostNotebooksResponse : RestApiResponse
    {
        public enum NotebookOnenoteUserRole
        {
            Owner,
            Contributor,
            Reader,
            None,
        }

        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsShared { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public NotebookLinks? Links { get; set; }
        public string? DisplayName { get; set; }
        public string? SectionGroupsUrl { get; set; }
        public string? SectionsUrl { get; set; }
        public string? Self { get; set; }
        public NotebookOnenoteUserRole UserRole { get; set; }
        public SectionGroup[]? SectionGroups { get; set; }
        public Section[]? Sections { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostNotebooksResponse> OnenotePostNotebooksAsync()
        {
            var p = new OnenotePostNotebooksParameter();
            return await this.SendAsync<OnenotePostNotebooksParameter, OnenotePostNotebooksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostNotebooksResponse> OnenotePostNotebooksAsync(CancellationToken cancellationToken)
        {
            var p = new OnenotePostNotebooksParameter();
            return await this.SendAsync<OnenotePostNotebooksParameter, OnenotePostNotebooksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostNotebooksResponse> OnenotePostNotebooksAsync(OnenotePostNotebooksParameter parameter)
        {
            return await this.SendAsync<OnenotePostNotebooksParameter, OnenotePostNotebooksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-post-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenotePostNotebooksResponse> OnenotePostNotebooksAsync(OnenotePostNotebooksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnenotePostNotebooksParameter, OnenotePostNotebooksResponse>(parameter, cancellationToken);
        }
    }
}
