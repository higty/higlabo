using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerbucketListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Buckets_Id_Tasks: return $"/planner/buckets/{Id}/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Buckets_Id_Tasks,
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
    public partial class PlannerbucketListTasksResponse : RestApiResponse<PlannerTask>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync()
        {
            var p = new PlannerbucketListTasksParameter();
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerbucketListTasksParameter();
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync(PlannerbucketListTasksParameter parameter)
        {
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync(PlannerbucketListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PlannerTask> PlannerbucketListTasksEnumerateAsync(PlannerbucketListTasksParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PlannerTask>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
