using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-update?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerbucketUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Buckets_Id: return $"/planner/buckets/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Buckets_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Name { get; set; }
        public string? OrderHint { get; set; }
    }
    public partial class PlannerbucketUpdateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? OrderHint { get; set; }
        public string? PlanId { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketUpdateResponse> PlannerbucketUpdateAsync()
        {
            var p = new PlannerbucketUpdateParameter();
            return await this.SendAsync<PlannerbucketUpdateParameter, PlannerbucketUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketUpdateResponse> PlannerbucketUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerbucketUpdateParameter();
            return await this.SendAsync<PlannerbucketUpdateParameter, PlannerbucketUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketUpdateResponse> PlannerbucketUpdateAsync(PlannerbucketUpdateParameter parameter)
        {
            return await this.SendAsync<PlannerbucketUpdateParameter, PlannerbucketUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketUpdateResponse> PlannerbucketUpdateAsync(PlannerbucketUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerbucketUpdateParameter, PlannerbucketUpdateResponse>(parameter, cancellationToken);
        }
    }
}
