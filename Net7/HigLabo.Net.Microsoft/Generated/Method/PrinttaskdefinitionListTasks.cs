using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class PrinttaskdefinitionListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TaskDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_TaskDefinitions_TaskDefinitionId_Tasks: return $"/print/taskDefinitions/{TaskDefinitionId}/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_TaskDefinitions_TaskDefinitionId_Tasks,
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
    public partial class PrinttaskdefinitionListTasksResponse : RestApiResponse
    {
        public PrintTask[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync()
        {
            var p = new PrinttaskdefinitionListTasksParameter();
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttaskdefinitionListTasksParameter();
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync(PrinttaskdefinitionListTasksParameter parameter)
        {
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync(PrinttaskdefinitionListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(parameter, cancellationToken);
        }
    }
}
