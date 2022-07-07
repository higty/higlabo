using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerbucketDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Planner_Buckets_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Buckets_Id: return $"/planner/buckets/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class PlannerbucketDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync()
        {
            var p = new PlannerbucketDeleteParameter();
            return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerbucketDeleteParameter();
            return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync(PlannerbucketDeleteParameter parameter)
        {
            return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync(PlannerbucketDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(parameter, cancellationToken);
        }
    }
}
