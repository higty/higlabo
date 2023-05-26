using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListGrouplifecyclepoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_GroupLifecyclePolicies: return $"/groups/{Id}/groupLifecyclePolicies";
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
            Groups_Id_GroupLifecyclePolicies,
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
    public partial class GroupListGrouplifecyclepoliciesResponse : RestApiResponse
    {
        public GroupLifecyclePolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync()
        {
            var p = new GroupListGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync(GroupListGrouplifecyclepoliciesParameter parameter)
        {
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListGrouplifecyclepoliciesResponse> GroupListGrouplifecyclepoliciesAsync(GroupListGrouplifecyclepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListGrouplifecyclepoliciesParameter, GroupListGrouplifecyclepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
