using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclepolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            GroupLifecyclePolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupLifecyclePolicies_Id: return $"/groupLifecyclePolicies/{Id}";
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
    public partial class GrouplifecyclepolicyGetResponse : RestApiResponse
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
        public async Task<GrouplifecyclepolicyGetResponse> GrouplifecyclepolicyGetAsync()
        {
            var p = new GrouplifecyclepolicyGetParameter();
            return await this.SendAsync<GrouplifecyclepolicyGetParameter, GrouplifecyclepolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyGetResponse> GrouplifecyclepolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclepolicyGetParameter();
            return await this.SendAsync<GrouplifecyclepolicyGetParameter, GrouplifecyclepolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyGetResponse> GrouplifecyclepolicyGetAsync(GrouplifecyclepolicyGetParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclepolicyGetParameter, GrouplifecyclepolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyGetResponse> GrouplifecyclepolicyGetAsync(GrouplifecyclepolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclepolicyGetParameter, GrouplifecyclepolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
