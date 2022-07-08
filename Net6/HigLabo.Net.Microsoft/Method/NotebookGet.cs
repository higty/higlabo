using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NotebookGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string GroupsId { get; set; }
            public string NotebooksId { get; set; }
            public string SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Notebooks_Id: return $"/me/onenote/notebooks/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_Id: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/{Id}";
                    case ApiPath.Groups_Id_Onenote_Notebooks_Id: return $"/groups/{GroupsId}/onenote/notebooks/{NotebooksId}";
                    case ApiPath.Sites_Id_Onenote_Notebooks_Id: return $"/sites/{SitesId}/onenote/notebooks/{NotebooksId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedBy,
            CreatedDateTime,
            Id,
            IsDefault,
            IsShared,
            LastModifiedBy,
            LastModifiedDateTime,
            Links,
            DisplayName,
            SectionGroupsUrl,
            SectionsUrl,
            Self,
            UserRole,
            SectionGroups,
            Sections,
        }
        public enum ApiPath
        {
            Me_Onenote_Notebooks_Id,
            Users_IdOrUserPrincipalName_Onenote_Notebooks_Id,
            Groups_Id_Onenote_Notebooks_Id,
            Sites_Id_Onenote_Notebooks_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class NotebookGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/notebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetResponse> NotebookGetAsync()
        {
            var p = new NotebookGetParameter();
            return await this.SendAsync<NotebookGetParameter, NotebookGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetResponse> NotebookGetAsync(CancellationToken cancellationToken)
        {
            var p = new NotebookGetParameter();
            return await this.SendAsync<NotebookGetParameter, NotebookGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetResponse> NotebookGetAsync(NotebookGetParameter parameter)
        {
            return await this.SendAsync<NotebookGetParameter, NotebookGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetResponse> NotebookGetAsync(NotebookGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NotebookGetParameter, NotebookGetResponse>(parameter, cancellationToken);
        }
    }
}
