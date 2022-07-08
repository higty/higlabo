using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerbuckettaskboardtaskformatUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Tasks_Id_BucketTaskBoardFormat: return $"/planner/tasks/{Id}/bucketTaskBoardFormat";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Tasks_Id_BucketTaskBoardFormat,
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
        public string? OrderHint { get; set; }
    }
    public partial class PlannerbuckettaskboardtaskformatUpdateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? OrderHint { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatUpdateResponse> PlannerbuckettaskboardtaskformatUpdateAsync()
        {
            var p = new PlannerbuckettaskboardtaskformatUpdateParameter();
            return await this.SendAsync<PlannerbuckettaskboardtaskformatUpdateParameter, PlannerbuckettaskboardtaskformatUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatUpdateResponse> PlannerbuckettaskboardtaskformatUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerbuckettaskboardtaskformatUpdateParameter();
            return await this.SendAsync<PlannerbuckettaskboardtaskformatUpdateParameter, PlannerbuckettaskboardtaskformatUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatUpdateResponse> PlannerbuckettaskboardtaskformatUpdateAsync(PlannerbuckettaskboardtaskformatUpdateParameter parameter)
        {
            return await this.SendAsync<PlannerbuckettaskboardtaskformatUpdateParameter, PlannerbuckettaskboardtaskformatUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatUpdateResponse> PlannerbuckettaskboardtaskformatUpdateAsync(PlannerbuckettaskboardtaskformatUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerbuckettaskboardtaskformatUpdateParameter, PlannerbuckettaskboardtaskformatUpdateResponse>(parameter, cancellationToken);
        }
    }
}
