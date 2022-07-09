using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenoteListNotebooksParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class OnenoteListNotebooksResponse : RestApiResponse
    {
        public Notebook[]? Value { get; set; }
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
