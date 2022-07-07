using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalaccesspolicyDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class ConditionalaccesspolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyDeleteResponse> ConditionalaccesspolicyDeleteAsync()
        {
            var p = new ConditionalaccesspolicyDeleteParameter();
            return await this.SendAsync<ConditionalaccesspolicyDeleteParameter, ConditionalaccesspolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyDeleteResponse> ConditionalaccesspolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalaccesspolicyDeleteParameter();
            return await this.SendAsync<ConditionalaccesspolicyDeleteParameter, ConditionalaccesspolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyDeleteResponse> ConditionalaccesspolicyDeleteAsync(ConditionalaccesspolicyDeleteParameter parameter)
        {
            return await this.SendAsync<ConditionalaccesspolicyDeleteParameter, ConditionalaccesspolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccesspolicyDeleteResponse> ConditionalaccesspolicyDeleteAsync(ConditionalaccesspolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalaccesspolicyDeleteParameter, ConditionalaccesspolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
