using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenoteListNotebooksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_Notebooks,
            Users_IdOrUserPrincipalName_Onenote_Notebooks,
            Groups_Id_Onenote_Notebooks,
            Sites_Id_Onenote_Notebooks,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Notebooks: return $"/me/onenote/notebooks";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks";
                    case ApiPath.Groups_Id_Onenote_Notebooks: return $"/groups/{Id}/onenote/notebooks";
                    case ApiPath.Sites_Id_Onenote_Notebooks: return $"/sites/{Id}/onenote/notebooks";
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
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class OnenoteListNotebooksResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/notebook?view=graph-rest-1.0
        /// </summary>
        public partial class Notebook
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
        }

        public Notebook[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync()
        {
            var p = new OnenoteListNotebooksParameter();
            return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync(CancellationToken cancellationToken)
        {
            var p = new OnenoteListNotebooksParameter();
            return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync(OnenoteListNotebooksParameter parameter)
        {
            return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync(OnenoteListNotebooksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(parameter, cancellationToken);
        }
    }
}
