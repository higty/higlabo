using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NotebookGetrecentnotebooksParameter : IRestApiParameter, IQueryParameterProperty
    {
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
        }
        public enum ApiPath
        {
            Me_Onenote_Notebooks_GetRecentNotebooks,
            Users_IdOrUserPrincipalName_Onenote_Notebooks_GetRecentNotebooks,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Notebooks_GetRecentNotebooks: return $"/me/onenote/notebooks/getRecentNotebooks";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_GetRecentNotebooks: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/getRecentNotebooks";
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
    }
    public partial class NotebookGetrecentnotebooksResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-getrecentnotebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetrecentnotebooksResponse> NotebookGetrecentnotebooksAsync()
        {
            var p = new NotebookGetrecentnotebooksParameter();
            return await this.SendAsync<NotebookGetrecentnotebooksParameter, NotebookGetrecentnotebooksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-getrecentnotebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetrecentnotebooksResponse> NotebookGetrecentnotebooksAsync(CancellationToken cancellationToken)
        {
            var p = new NotebookGetrecentnotebooksParameter();
            return await this.SendAsync<NotebookGetrecentnotebooksParameter, NotebookGetrecentnotebooksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-getrecentnotebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetrecentnotebooksResponse> NotebookGetrecentnotebooksAsync(NotebookGetrecentnotebooksParameter parameter)
        {
            return await this.SendAsync<NotebookGetrecentnotebooksParameter, NotebookGetrecentnotebooksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-getrecentnotebooks?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookGetrecentnotebooksResponse> NotebookGetrecentnotebooksAsync(NotebookGetrecentnotebooksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NotebookGetrecentnotebooksParameter, NotebookGetrecentnotebooksResponse>(parameter, cancellationToken);
        }
    }
}
