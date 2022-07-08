using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerbuckettaskboardtaskformatGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class PlannerbuckettaskboardtaskformatGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? OrderHint { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync()
        {
            var p = new PlannerbuckettaskboardtaskformatGetParameter();
            return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerbuckettaskboardtaskformatGetParameter();
            return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync(PlannerbuckettaskboardtaskformatGetParameter parameter)
        {
            return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync(PlannerbuckettaskboardtaskformatGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(parameter, cancellationToken);
        }
    }
}
