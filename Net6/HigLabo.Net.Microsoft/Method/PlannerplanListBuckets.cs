using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerplanListBucketsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Plans_PlanId_Buckets,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Plans_PlanId_Buckets: return $"/planner/plans/{PlanId}/buckets";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string PlanId { get; set; }
    }
    public partial class PlannerplanListBucketsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/plannerbucket?view=graph-rest-1.0
        /// </summary>
        public partial class PlannerBucket
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? OrderHint { get; set; }
            public string? PlanId { get; set; }
        }

        public PlannerBucket[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync()
        {
            var p = new PlannerplanListBucketsParameter();
            return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerplanListBucketsParameter();
            return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync(PlannerplanListBucketsParameter parameter)
        {
            return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync(PlannerplanListBucketsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(parameter, cancellationToken);
        }
    }
}
