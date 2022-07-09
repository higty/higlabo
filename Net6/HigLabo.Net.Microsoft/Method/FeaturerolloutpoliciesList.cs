using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutpoliciesListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies: return $"/policies/featureRolloutPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Description,
            DisplayName,
            Feature,
            Id,
            IsAppliedToOrganization,
            IsEnabled,
            AppliesTo,
        }
        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class FeaturerolloutpoliciesListResponse : RestApiResponse
    {
        public FeatureRolloutPolicy[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync()
        {
            var p = new FeaturerolloutpoliciesListParameter();
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpoliciesListParameter();
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(FeaturerolloutpoliciesListParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(FeaturerolloutpoliciesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(parameter, cancellationToken);
        }
    }
}
