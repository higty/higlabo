using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalAccessPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_Policies_Id: return $"/identity/conditionalAccess/policies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_ConditionalAccess_Policies_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class ConditionalAccessPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyUpdateResponse> ConditionalAccessPolicyUpdateAsync()
        {
            var p = new ConditionalAccessPolicyUpdateParameter();
            return await this.SendAsync<ConditionalAccessPolicyUpdateParameter, ConditionalAccessPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyUpdateResponse> ConditionalAccessPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessPolicyUpdateParameter();
            return await this.SendAsync<ConditionalAccessPolicyUpdateParameter, ConditionalAccessPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyUpdateResponse> ConditionalAccessPolicyUpdateAsync(ConditionalAccessPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessPolicyUpdateParameter, ConditionalAccessPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyUpdateResponse> ConditionalAccessPolicyUpdateAsync(ConditionalAccessPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessPolicyUpdateParameter, ConditionalAccessPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
