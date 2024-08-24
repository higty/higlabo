using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerUserListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Planner_Tasks: return $"/me/planner/tasks";
                    case ApiPath.Users_Id_Planner_Tasks: return $"/users/{Id}/planner/tasks";
                    case ApiPath.Drive_Root_CreatedByUser_Planner_Tasks: return $"/drive/root/createdByUser/planner/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Planner_Tasks,
            Users_Id_Planner_Tasks,
            Drive_Root_CreatedByUser_Planner_Tasks,
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
    public partial class PlannerUserListTasksResponse : RestApiResponse<PlannerTask>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerUserListTasksResponse> PlannerUserListTasksAsync()
        {
            var p = new PlannerUserListTasksParameter();
            return await this.SendAsync<PlannerUserListTasksParameter, PlannerUserListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerUserListTasksResponse> PlannerUserListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerUserListTasksParameter();
            return await this.SendAsync<PlannerUserListTasksParameter, PlannerUserListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerUserListTasksResponse> PlannerUserListTasksAsync(PlannerUserListTasksParameter parameter)
        {
            return await this.SendAsync<PlannerUserListTasksParameter, PlannerUserListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerUserListTasksResponse> PlannerUserListTasksAsync(PlannerUserListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerUserListTasksParameter, PlannerUserListTasksResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PlannerTask> PlannerUserListTasksEnumerateAsync(PlannerUserListTasksParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PlannerUserListTasksParameter, PlannerUserListTasksResponse>(parameter, cancellationToken);
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
