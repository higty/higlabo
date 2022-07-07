using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenoteListSectiongroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_SectionGroups,
            Users_IdOrUserPrincipalName_Onenote_SectionGroups,
            Groups_Id_Onenote_SectionGroups,
            Sites_Id_Onenote_SectionGroups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_SectionGroups: return $"/me/onenote/sectionGroups";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_SectionGroups: return $"/users/{IdOrUserPrincipalName}/onenote/sectionGroups";
                    case ApiPath.Groups_Id_Onenote_SectionGroups: return $"/groups/{Id}/onenote/sectionGroups";
                    case ApiPath.Sites_Id_Onenote_SectionGroups: return $"/sites/{Id}/onenote/sectionGroups";
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
    public partial class OnenoteListSectiongroupsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectiongroupsResponse> OnenoteListSectiongroupsAsync()
        {
            var p = new OnenoteListSectiongroupsParameter();
            return await this.SendAsync<OnenoteListSectiongroupsParameter, OnenoteListSectiongroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectiongroupsResponse> OnenoteListSectiongroupsAsync(CancellationToken cancellationToken)
        {
            var p = new OnenoteListSectiongroupsParameter();
            return await this.SendAsync<OnenoteListSectiongroupsParameter, OnenoteListSectiongroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectiongroupsResponse> OnenoteListSectiongroupsAsync(OnenoteListSectiongroupsParameter parameter)
        {
            return await this.SendAsync<OnenoteListSectiongroupsParameter, OnenoteListSectiongroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectiongroupsResponse> OnenoteListSectiongroupsAsync(OnenoteListSectiongroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnenoteListSectiongroupsParameter, OnenoteListSectiongroupsResponse>(parameter, cancellationToken);
        }
    }
}
