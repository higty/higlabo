using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclepolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            GroupLifecyclePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupLifecyclePolicies: return $"/groupLifecyclePolicies";
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
    }
    public partial class GrouplifecyclepolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/grouplifecyclepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class GroupLifecyclePolicy
        {
            public string? AlternateNotificationEmails { get; set; }
            public Int32? GroupLifetimeInDays { get; set; }
            public string? Id { get; set; }
            public string? ManagedGroupTypes { get; set; }
        }

        public GroupLifecyclePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyListResponse> GrouplifecyclepolicyListAsync()
        {
            var p = new GrouplifecyclepolicyListParameter();
            return await this.SendAsync<GrouplifecyclepolicyListParameter, GrouplifecyclepolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyListResponse> GrouplifecyclepolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclepolicyListParameter();
            return await this.SendAsync<GrouplifecyclepolicyListParameter, GrouplifecyclepolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyListResponse> GrouplifecyclepolicyListAsync(GrouplifecyclepolicyListParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclepolicyListParameter, GrouplifecyclepolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyListResponse> GrouplifecyclepolicyListAsync(GrouplifecyclepolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclepolicyListParameter, GrouplifecyclepolicyListResponse>(parameter, cancellationToken);
        }
    }
}
