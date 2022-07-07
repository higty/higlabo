using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalaccesspolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_Policies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ConditionalAccess_Policies_Id: return $"/identity/conditionalAccess/policies/{Id}";
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
    public partial class ConditionalaccesspolicyGetResponse : RestApiResponse
    {
        public enum ConditionalAccessPolicyConditionalAccessPolicyState
        {
            Enabled,
            Disabled,
            EnabledForReportingButNotEnforced,
        }

        public ConditionalAccessConditionSet? Conditions { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public ConditionalAccessGrantControls? GrantControls { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public ConditionalAccessSessionControls? SessionControls { get; set; }
        public ConditionalAccessPolicyConditionalAccessPolicyState State { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyGetResponse> ConditionalaccesspolicyGetAsync()
        {
            var p = new ConditionalaccesspolicyGetParameter();
            return await this.SendAsync<ConditionalaccesspolicyGetParameter, ConditionalaccesspolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyGetResponse> ConditionalaccesspolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalaccesspolicyGetParameter();
            return await this.SendAsync<ConditionalaccesspolicyGetParameter, ConditionalaccesspolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyGetResponse> ConditionalaccesspolicyGetAsync(ConditionalaccesspolicyGetParameter parameter)
        {
            return await this.SendAsync<ConditionalaccesspolicyGetParameter, ConditionalaccesspolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyGetResponse> ConditionalaccesspolicyGetAsync(ConditionalaccesspolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalaccesspolicyGetParameter, ConditionalaccesspolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
