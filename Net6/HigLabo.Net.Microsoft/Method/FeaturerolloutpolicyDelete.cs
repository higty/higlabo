using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutpolicyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies_Id: return $"/policies/featureRolloutPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class FeaturerolloutpolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteResponse> FeaturerolloutpolicyDeleteAsync()
        {
            var p = new FeaturerolloutpolicyDeleteParameter();
            return await this.SendAsync<FeaturerolloutpolicyDeleteParameter, FeaturerolloutpolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteResponse> FeaturerolloutpolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpolicyDeleteParameter();
            return await this.SendAsync<FeaturerolloutpolicyDeleteParameter, FeaturerolloutpolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteResponse> FeaturerolloutpolicyDeleteAsync(FeaturerolloutpolicyDeleteParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpolicyDeleteParameter, FeaturerolloutpolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyDeleteResponse> FeaturerolloutpolicyDeleteAsync(FeaturerolloutpolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpolicyDeleteParameter, FeaturerolloutpolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
