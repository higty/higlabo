using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclePolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupLifecyclePolicies_Id: return $"/groupLifecyclePolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            GroupLifecyclePolicies_Id,
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
    public partial class GrouplifecyclePolicyGetResponse : RestApiResponse
    {
        public string? AlternateNotificationEmails { get; set; }
        public Int32? GroupLifetimeInDays { get; set; }
        public string? Id { get; set; }
        public string? ManagedGroupTypes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyGetResponse> GrouplifecyclePolicyGetAsync()
        {
            var p = new GrouplifecyclePolicyGetParameter();
            return await this.SendAsync<GrouplifecyclePolicyGetParameter, GrouplifecyclePolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyGetResponse> GrouplifecyclePolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclePolicyGetParameter();
            return await this.SendAsync<GrouplifecyclePolicyGetParameter, GrouplifecyclePolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyGetResponse> GrouplifecyclePolicyGetAsync(GrouplifecyclePolicyGetParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclePolicyGetParameter, GrouplifecyclePolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyGetResponse> GrouplifecyclePolicyGetAsync(GrouplifecyclePolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclePolicyGetParameter, GrouplifecyclePolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
