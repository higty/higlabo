using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannertaskDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Planner_Tasks_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Tasks_Id: return $"/planner/tasks/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class PlannertaskDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskDeleteResponse> PlannertaskDeleteAsync()
        {
            var p = new PlannertaskDeleteParameter();
            return await this.SendAsync<PlannertaskDeleteParameter, PlannertaskDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskDeleteResponse> PlannertaskDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PlannertaskDeleteParameter();
            return await this.SendAsync<PlannertaskDeleteParameter, PlannertaskDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskDeleteResponse> PlannertaskDeleteAsync(PlannertaskDeleteParameter parameter)
        {
            return await this.SendAsync<PlannertaskDeleteParameter, PlannertaskDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskDeleteResponse> PlannertaskDeleteAsync(PlannertaskDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannertaskDeleteParameter, PlannertaskDeleteResponse>(parameter, cancellationToken);
        }
    }
}
