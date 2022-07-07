using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListAcceptedsendersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_AcceptedSenders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_AcceptedSenders: return $"/groups/{Id}/acceptedSenders";
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
    public partial class GroupListAcceptedsendersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync()
        {
            var p = new GroupListAcceptedsendersParameter();
            return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListAcceptedsendersParameter();
            return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync(GroupListAcceptedsendersParameter parameter)
        {
            return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync(GroupListAcceptedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(parameter, cancellationToken);
        }
    }
}
