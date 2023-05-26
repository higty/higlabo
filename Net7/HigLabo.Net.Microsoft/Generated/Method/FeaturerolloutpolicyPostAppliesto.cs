using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class FeaturerolloutPolicyPostAppliestoParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies_Id_AppliesTo_ref: return $"/policies/featureRolloutPolicies/{Id}/appliesTo/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies_Id_AppliesTo_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class FeaturerolloutPolicyPostAppliestoResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyPostAppliestoResponse> FeaturerolloutPolicyPostAppliestoAsync()
        {
            var p = new FeaturerolloutPolicyPostAppliestoParameter();
            return await this.SendAsync<FeaturerolloutPolicyPostAppliestoParameter, FeaturerolloutPolicyPostAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyPostAppliestoResponse> FeaturerolloutPolicyPostAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutPolicyPostAppliestoParameter();
            return await this.SendAsync<FeaturerolloutPolicyPostAppliestoParameter, FeaturerolloutPolicyPostAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyPostAppliestoResponse> FeaturerolloutPolicyPostAppliestoAsync(FeaturerolloutPolicyPostAppliestoParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutPolicyPostAppliestoParameter, FeaturerolloutPolicyPostAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyPostAppliestoResponse> FeaturerolloutPolicyPostAppliestoAsync(FeaturerolloutPolicyPostAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutPolicyPostAppliestoParameter, FeaturerolloutPolicyPostAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
