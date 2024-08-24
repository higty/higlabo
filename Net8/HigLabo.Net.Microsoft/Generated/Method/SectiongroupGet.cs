using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
    /// </summary>
    public partial class SectionGroupGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? SectionGroupsId { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_SectionGroups_Id: return $"/me/onenote/sectionGroups/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_SectionGroups_Id: return $"/users/{IdOrUserPrincipalName}/onenote/sectionGroups/{Id}";
                    case ApiPath.Groups_Id_Onenote_SectionGroups_Id: return $"/groups/{GroupsId}/onenote/sectionGroups/{SectionGroupsId}";
                    case ApiPath.Sites_Id_Onenote_SectionGroups_Id: return $"/sites/{SitesId}/onenote/sectionGroups/{SectionGroupsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_SectionGroups_Id,
            Users_IdOrUserPrincipalName_Onenote_SectionGroups_Id,
            Groups_Id_Onenote_SectionGroups_Id,
            Sites_Id_Onenote_SectionGroups_Id,
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
    public partial class SectionGroupGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGroupGetResponse> SectionGroupGetAsync()
        {
            var p = new SectionGroupGetParameter();
            return await this.SendAsync<SectionGroupGetParameter, SectionGroupGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGroupGetResponse> SectionGroupGetAsync(CancellationToken cancellationToken)
        {
            var p = new SectionGroupGetParameter();
            return await this.SendAsync<SectionGroupGetParameter, SectionGroupGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGroupGetResponse> SectionGroupGetAsync(SectionGroupGetParameter parameter)
        {
            return await this.SendAsync<SectionGroupGetParameter, SectionGroupGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGroupGetResponse> SectionGroupGetAsync(SectionGroupGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectionGroupGetParameter, SectionGroupGetResponse>(parameter, cancellationToken);
        }
    }
}
