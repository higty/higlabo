using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewsetListHistoryDefinitionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions: return $"/identityGovernance/accessReviews/historyDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_HistoryDefinitions,
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
    public partial class AccessReviewsetListHistoryDefinitionsResponse : RestApiResponse<AccessReviewHistoryDefinition>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewsetListHistoryDefinitionsResponse> AccessReviewsetListHistoryDefinitionsAsync()
        {
            var p = new AccessReviewsetListHistoryDefinitionsParameter();
            return await this.SendAsync<AccessReviewsetListHistoryDefinitionsParameter, AccessReviewsetListHistoryDefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewsetListHistoryDefinitionsResponse> AccessReviewsetListHistoryDefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewsetListHistoryDefinitionsParameter();
            return await this.SendAsync<AccessReviewsetListHistoryDefinitionsParameter, AccessReviewsetListHistoryDefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewsetListHistoryDefinitionsResponse> AccessReviewsetListHistoryDefinitionsAsync(AccessReviewsetListHistoryDefinitionsParameter parameter)
        {
            return await this.SendAsync<AccessReviewsetListHistoryDefinitionsParameter, AccessReviewsetListHistoryDefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewsetListHistoryDefinitionsResponse> AccessReviewsetListHistoryDefinitionsAsync(AccessReviewsetListHistoryDefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewsetListHistoryDefinitionsParameter, AccessReviewsetListHistoryDefinitionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessReviewHistoryDefinition> AccessReviewsetListHistoryDefinitionsEnumerateAsync(AccessReviewsetListHistoryDefinitionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessReviewsetListHistoryDefinitionsParameter, AccessReviewsetListHistoryDefinitionsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessReviewHistoryDefinition>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
