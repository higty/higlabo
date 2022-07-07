using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListRejectedsendersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_RejectedSenders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_RejectedSenders: return $"/groups/{Id}/rejectedSenders";
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
    public partial class GroupListRejectedsendersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync()
        {
            var p = new GroupListRejectedsendersParameter();
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListRejectedsendersParameter();
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync(GroupListRejectedsendersParameter parameter)
        {
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync(GroupListRejectedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(parameter, cancellationToken);
        }
    }
}
