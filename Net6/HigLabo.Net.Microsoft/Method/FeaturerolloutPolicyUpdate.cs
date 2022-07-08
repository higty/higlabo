using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies_Id: return $"/policies/featureRolloutPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies_Id,
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
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsAppliedToOrganization { get; set; }
        public bool? IsEnabled { get; set; }
    }
    public partial class FeaturerolloutPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyUpdateResponse> FeaturerolloutPolicyUpdateAsync()
        {
            var p = new FeaturerolloutPolicyUpdateParameter();
            return await this.SendAsync<FeaturerolloutPolicyUpdateParameter, FeaturerolloutPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyUpdateResponse> FeaturerolloutPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutPolicyUpdateParameter();
            return await this.SendAsync<FeaturerolloutPolicyUpdateParameter, FeaturerolloutPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyUpdateResponse> FeaturerolloutPolicyUpdateAsync(FeaturerolloutPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutPolicyUpdateParameter, FeaturerolloutPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyUpdateResponse> FeaturerolloutPolicyUpdateAsync(FeaturerolloutPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutPolicyUpdateParameter, FeaturerolloutPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
