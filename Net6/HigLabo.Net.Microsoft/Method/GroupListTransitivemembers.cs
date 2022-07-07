using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListTransitivemembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_TransitiveMembers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_TransitiveMembers: return $"/groups/{Id}/transitiveMembers";
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
    public partial class GroupListTransitivemembersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync()
        {
            var p = new GroupListTransitivemembersParameter();
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListTransitivemembersParameter();
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync(GroupListTransitivemembersParameter parameter)
        {
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync(GroupListTransitivemembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(parameter, cancellationToken);
        }
    }
}
