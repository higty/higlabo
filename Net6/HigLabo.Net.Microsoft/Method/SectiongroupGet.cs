using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectiongroupGetParameter : IRestApiParameter, IQueryParameterProperty
    {
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

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_SectionGroups_Id: return $"/me/onenote/sectionGroups/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_SectionGroups_Id: return $"/users/{IdOrUserPrincipalName}/onenote/sectionGroups/{Id}";
                    case ApiPath.Groups_Id_Onenote_SectionGroups_Id: return $"/groups/{GroupsId}/onenote/sectionGroups/{SectionGroupsId}";
                    case ApiPath.Sites_Id_Onenote_SectionGroups_Id: return $"/sites/{SitesId}/onenote/sectionGroups/{SectionGroupsId}";
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
        public string SectionGroupsId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class SectiongroupGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupGetResponse> SectiongroupGetAsync()
        {
            var p = new SectiongroupGetParameter();
            return await this.SendAsync<SectiongroupGetParameter, SectiongroupGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupGetResponse> SectiongroupGetAsync(CancellationToken cancellationToken)
        {
            var p = new SectiongroupGetParameter();
            return await this.SendAsync<SectiongroupGetParameter, SectiongroupGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupGetResponse> SectiongroupGetAsync(SectiongroupGetParameter parameter)
        {
            return await this.SendAsync<SectiongroupGetParameter, SectiongroupGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupGetResponse> SectiongroupGetAsync(SectiongroupGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectiongroupGetParameter, SectiongroupGetResponse>(parameter, cancellationToken);
        }
    }
}
