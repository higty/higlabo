using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class FeaturerolloutPolicyDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class FeaturerolloutPolicyDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyDeleteResponse> FeaturerolloutPolicyDeleteAsync()
        {
            var p = new FeaturerolloutPolicyDeleteParameter();
            return await this.SendAsync<FeaturerolloutPolicyDeleteParameter, FeaturerolloutPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyDeleteResponse> FeaturerolloutPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutPolicyDeleteParameter();
            return await this.SendAsync<FeaturerolloutPolicyDeleteParameter, FeaturerolloutPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyDeleteResponse> FeaturerolloutPolicyDeleteAsync(FeaturerolloutPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutPolicyDeleteParameter, FeaturerolloutPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyDeleteResponse> FeaturerolloutPolicyDeleteAsync(FeaturerolloutPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutPolicyDeleteParameter, FeaturerolloutPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
