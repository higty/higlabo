using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class GrouplifecyclePolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupLifecyclePolicies: return $"/groupLifecyclePolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AlternateNotificationEmails,
            GroupLifetimeInDays,
            Id,
            ManagedGroupTypes,
        }
        public enum ApiPath
        {
            GroupLifecyclePolicies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class GrouplifecyclePolicyListResponse : RestApiResponse
    {
        public GroupLifecyclePolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyListResponse> GrouplifecyclePolicyListAsync()
        {
            var p = new GrouplifecyclePolicyListParameter();
            return await this.SendAsync<GrouplifecyclePolicyListParameter, GrouplifecyclePolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyListResponse> GrouplifecyclePolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclePolicyListParameter();
            return await this.SendAsync<GrouplifecyclePolicyListParameter, GrouplifecyclePolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyListResponse> GrouplifecyclePolicyListAsync(GrouplifecyclePolicyListParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclePolicyListParameter, GrouplifecyclePolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyListResponse> GrouplifecyclePolicyListAsync(GrouplifecyclePolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclePolicyListParameter, GrouplifecyclePolicyListResponse>(parameter, cancellationToken);
        }
    }
}
