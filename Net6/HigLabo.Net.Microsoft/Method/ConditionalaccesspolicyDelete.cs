using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalAccessPolicyDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ConditionalAccessPolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyDeleteResponse> ConditionalAccessPolicyDeleteAsync()
        {
            var p = new ConditionalAccessPolicyDeleteParameter();
            return await this.SendAsync<ConditionalAccessPolicyDeleteParameter, ConditionalAccessPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyDeleteResponse> ConditionalAccessPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessPolicyDeleteParameter();
            return await this.SendAsync<ConditionalAccessPolicyDeleteParameter, ConditionalAccessPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyDeleteResponse> ConditionalAccessPolicyDeleteAsync(ConditionalAccessPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessPolicyDeleteParameter, ConditionalAccessPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccesspolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessPolicyDeleteResponse> ConditionalAccessPolicyDeleteAsync(ConditionalAccessPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessPolicyDeleteParameter, ConditionalAccessPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
