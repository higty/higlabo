using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleListMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryRoles_RoleId_Members,
            DirectoryRoles_RoleTemplateId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoles_RoleId_Members: return $"/directoryRoles/{RoleId}/members";
                    case ApiPath.DirectoryRoles_RoleTemplateId: return $"/directoryRoles/roleTemplateId";
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
        public string RoleId { get; set; }
    }
    public partial class DirectoryroleListMembersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListMembersResponse> DirectoryroleListMembersAsync()
        {
            var p = new DirectoryroleListMembersParameter();
            return await this.SendAsync<DirectoryroleListMembersParameter, DirectoryroleListMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListMembersResponse> DirectoryroleListMembersAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleListMembersParameter();
            return await this.SendAsync<DirectoryroleListMembersParameter, DirectoryroleListMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListMembersResponse> DirectoryroleListMembersAsync(DirectoryroleListMembersParameter parameter)
        {
            return await this.SendAsync<DirectoryroleListMembersParameter, DirectoryroleListMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListMembersResponse> DirectoryroleListMembersAsync(DirectoryroleListMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleListMembersParameter, DirectoryroleListMembersResponse>(parameter, cancellationToken);
        }
    }
}
