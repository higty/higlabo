using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListGrouplifecyclepoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_GroupLifecyclePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_GroupLifecyclePolicies: return $"/groups/{Id}/groupLifecyclePolicies";
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
    public partial class GroupListGrouplifecyclepoliciesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync()
        {
            var p = new GroupListGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync(GroupListGrouplifecyclepoliciesParameter parameter)
        {
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync(GroupListGrouplifecyclepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
