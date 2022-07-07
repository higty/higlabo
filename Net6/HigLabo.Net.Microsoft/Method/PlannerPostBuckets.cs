using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerPostBucketsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Planner_Buckets,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Buckets: return $"/planner/buckets";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class PlannerPostBucketsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? OrderHint { get; set; }
        public string? PlanId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync()
        {
            var p = new PlannerPostBucketsParameter();
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerPostBucketsParameter();
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync(PlannerPostBucketsParameter parameter)
        {
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync(PlannerPostBucketsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(parameter, cancellationToken);
        }
    }
}
