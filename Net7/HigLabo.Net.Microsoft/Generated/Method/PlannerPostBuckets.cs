using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerPostBucketsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Buckets: return $"/planner/buckets";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Buckets,
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
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? OrderHint { get; set; }
        public string? PlanId { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
    public partial class PlannerPostBucketsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? OrderHint { get; set; }
        public string? PlanId { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync()
        {
            var p = new PlannerPostBucketsParameter();
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerPostBucketsParameter();
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync(PlannerPostBucketsParameter parameter)
        {
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-buckets?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostBucketsResponse> PlannerPostBucketsAsync(PlannerPostBucketsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerPostBucketsParameter, PlannerPostBucketsResponse>(parameter, cancellationToken);
        }
    }
}
