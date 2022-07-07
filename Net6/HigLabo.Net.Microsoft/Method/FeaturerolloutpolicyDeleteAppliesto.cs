using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutpolicyDeleteAppliestoParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies_PolicyId_AppliesTo_DirectoryObjectId_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies_PolicyId_AppliesTo_DirectoryObjectId_ref: return $"/policies/featureRolloutPolicies/{PolicyId}/appliesTo/{DirectoryObjectId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PolicyId { get; set; }
        public string DirectoryObjectId { get; set; }
    }
    public partial class FeaturerolloutpolicyDeleteAppliestoResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteAppliestoResponse> FeaturerolloutpolicyDeleteAppliestoAsync()
        {
            var p = new FeaturerolloutpolicyDeleteAppliestoParameter();
            return await this.SendAsync<FeaturerolloutpolicyDeleteAppliestoParameter, FeaturerolloutpolicyDeleteAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteAppliestoResponse> FeaturerolloutpolicyDeleteAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpolicyDeleteAppliestoParameter();
            return await this.SendAsync<FeaturerolloutpolicyDeleteAppliestoParameter, FeaturerolloutpolicyDeleteAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteAppliestoResponse> FeaturerolloutpolicyDeleteAppliestoAsync(FeaturerolloutpolicyDeleteAppliestoParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpolicyDeleteAppliestoParameter, FeaturerolloutpolicyDeleteAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteAppliestoResponse> FeaturerolloutpolicyDeleteAppliestoAsync(FeaturerolloutpolicyDeleteAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpolicyDeleteAppliestoParameter, FeaturerolloutpolicyDeleteAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
