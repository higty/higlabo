using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_MemberOf,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_MemberOf: return $"/groups/{Id}/memberOf";
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
    public partial class GroupListMemberofResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMemberofResponse> GroupListMemberofAsync()
        {
            var p = new GroupListMemberofParameter();
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMemberofResponse> GroupListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListMemberofParameter();
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMemberofResponse> GroupListMemberofAsync(GroupListMemberofParameter parameter)
        {
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListMemberofResponse> GroupListMemberofAsync(GroupListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
