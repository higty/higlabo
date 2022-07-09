using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannertaskDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Tasks_Id: return $"/planner/tasks/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Tasks_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
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
