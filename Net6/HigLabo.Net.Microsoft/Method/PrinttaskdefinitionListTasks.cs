using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinttaskdefinitionListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_TaskDefinitions_TaskDefinitionId_Tasks,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_TaskDefinitions_TaskDefinitionId_Tasks: return $"/print/taskDefinitions/{TaskDefinitionId}/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string TaskDefinitionId { get; set; }
    }
    public partial class PrinttaskdefinitionListTasksResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printtask?view=graph-rest-1.0
        /// </summary>
        public partial class PrintTask
        {
            public string? Id { get; set; }
            public PrintTaskStatus? Status { get; set; }
            public string? ParentUrl { get; set; }
        }

        public PrintTask[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync()
        {
            var p = new PrinttaskdefinitionListTasksParameter();
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttaskdefinitionListTasksParameter();
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync(PrinttaskdefinitionListTasksParameter parameter)
        {
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionListTasksResponse> PrinttaskdefinitionListTasksAsync(PrinttaskdefinitionListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttaskdefinitionListTasksParameter, PrinttaskdefinitionListTasksResponse>(parameter, cancellationToken);
        }
    }
}
