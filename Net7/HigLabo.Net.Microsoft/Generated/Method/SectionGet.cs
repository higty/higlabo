using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-get?view=graph-rest-1.0
    /// </summary>
    public partial class SectionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? SectionsId { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Sections_Id: return $"/me/onenote/sections/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}";
                    case ApiPath.Groups_Id_Onenote_Sections_Id: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}";
                    case ApiPath.Sites_Id_Onenote_Sections_Id: return $"/sites/{SitesId}/onenote/sections/{SectionsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedBy,
            CreatedDateTime,
            DisplayName,
            Id,
            IsDefault,
            LastModifiedBy,
            LastModifiedDateTime,
            Links,
            PagesUrl,
            Self,
            Pages,
            ParentNotebook,
            ParentSectionGroup,
        }
        public enum ApiPath
        {
            Me_Onenote_Sections_Id,
            Users_IdOrUserPrincipalName_Onenote_Sections_Id,
            Groups_Id_Onenote_Sections_Id,
            Sites_Id_Onenote_Sections_Id,
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
    public partial class SectionGetResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsDefault { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public SectionLinks? Links { get; set; }
        public string? PagesUrl { get; set; }
        public string? Self { get; set; }
        public Page[]? Pages { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public SectionGroup? ParentSectionGroup { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGetResponse> SectionGetAsync()
        {
            var p = new SectionGetParameter();
            return await this.SendAsync<SectionGetParameter, SectionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGetResponse> SectionGetAsync(CancellationToken cancellationToken)
        {
            var p = new SectionGetParameter();
            return await this.SendAsync<SectionGetParameter, SectionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGetResponse> SectionGetAsync(SectionGetParameter parameter)
        {
            return await this.SendAsync<SectionGetParameter, SectionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionGetResponse> SectionGetAsync(SectionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectionGetParameter, SectionGetResponse>(parameter, cancellationToken);
        }
    }
}
