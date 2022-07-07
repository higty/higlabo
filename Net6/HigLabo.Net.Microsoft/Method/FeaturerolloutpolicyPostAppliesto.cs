using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutpolicyPostAppliestoParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies_Id_AppliesTo_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies_Id_AppliesTo_ref: return $"/policies/featureRolloutPolicies/{Id}/appliesTo/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class FeaturerolloutpolicyPostAppliestoResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyPostAppliestoResponse> FeaturerolloutpolicyPostAppliestoAsync()
        {
            var p = new FeaturerolloutpolicyPostAppliestoParameter();
            return await this.SendAsync<FeaturerolloutpolicyPostAppliestoParameter, FeaturerolloutpolicyPostAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyPostAppliestoResponse> FeaturerolloutpolicyPostAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpolicyPostAppliestoParameter();
            return await this.SendAsync<FeaturerolloutpolicyPostAppliestoParameter, FeaturerolloutpolicyPostAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyPostAppliestoResponse> FeaturerolloutpolicyPostAppliestoAsync(FeaturerolloutpolicyPostAppliestoParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpolicyPostAppliestoParameter, FeaturerolloutpolicyPostAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyPostAppliestoResponse> FeaturerolloutpolicyPostAppliestoAsync(FeaturerolloutpolicyPostAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpolicyPostAppliestoParameter, FeaturerolloutpolicyPostAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
