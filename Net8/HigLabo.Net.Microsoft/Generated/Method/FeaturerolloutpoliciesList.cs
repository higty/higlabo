using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
    /// </summary>
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
    public partial class FeaturerolloutpoliciesListResponse : RestApiResponse<FeatureRolloutPolicy>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync()
        {
            var p = new FeaturerolloutpoliciesListParameter();
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpoliciesListParameter();
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(FeaturerolloutpoliciesListParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(FeaturerolloutpoliciesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<FeatureRolloutPolicy> FeaturerolloutpoliciesListEnumerateAsync(FeaturerolloutpoliciesListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<FeatureRolloutPolicy>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
