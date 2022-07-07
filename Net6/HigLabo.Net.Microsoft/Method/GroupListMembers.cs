using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Members,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Members: return $"/groups/{Id}/members";
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
    }
    public partial class GroupListMembersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMembersResponse> GroupListMembersAsync()
        {
            var p = new GroupListMembersParameter();
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMembersResponse> GroupListMembersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListMembersParameter();
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMembersResponse> GroupListMembersAsync(GroupListMembersParameter parameter)
        {
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMembersResponse> GroupListMembersAsync(GroupListMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(parameter, cancellationToken);
        }
    }
}
