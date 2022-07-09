using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerbucketGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class PlannerbucketGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? OrderHint { get; set; }
        public string? PlanId { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketGetResponse> PlannerbucketGetAsync()
        {
            var p = new PlannerbucketGetParameter();
            return await this.SendAsync<PlannerbucketGetParameter, PlannerbucketGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketGetResponse> PlannerbucketGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerbucketGetParameter();
            return await this.SendAsync<PlannerbucketGetParameter, PlannerbucketGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketGetResponse> PlannerbucketGetAsync(PlannerbucketGetParameter parameter)
        {
            return await this.SendAsync<PlannerbucketGetParameter, PlannerbucketGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketGetResponse> PlannerbucketGetAsync(PlannerbucketGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerbucketGetParameter, PlannerbucketGetResponse>(parameter, cancellationToken);
        }
    }
}
