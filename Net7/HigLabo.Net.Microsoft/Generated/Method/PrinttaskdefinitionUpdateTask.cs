using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
    /// </summary>
    public partial class PrinttaskdefinitionUpdateTaskParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TaskDefinitionId { get; set; }
            public string? TaskId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_TaskDefinitions_TaskDefinitionId_Tasks_TaskId: return $"/print/taskDefinitions/{TaskDefinitionId}/tasks/{TaskId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_TaskDefinitions_TaskDefinitionId_Tasks_TaskId,
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
        public string? Status { get; set; }
    }
    public partial class PrinttaskdefinitionUpdateTaskResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PrintTaskStatus? Status { get; set; }
        public string? ParentUrl { get; set; }
        public PrintTaskDefinition? Definition { get; set; }
        public PrintTaskTrigger? Trigger { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionUpdateTaskResponse> PrinttaskdefinitionUpdateTaskAsync()
        {
            var p = new PrinttaskdefinitionUpdateTaskParameter();
            return await this.SendAsync<PrinttaskdefinitionUpdateTaskParameter, PrinttaskdefinitionUpdateTaskResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionUpdateTaskResponse> PrinttaskdefinitionUpdateTaskAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttaskdefinitionUpdateTaskParameter();
            return await this.SendAsync<PrinttaskdefinitionUpdateTaskParameter, PrinttaskdefinitionUpdateTaskResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionUpdateTaskResponse> PrinttaskdefinitionUpdateTaskAsync(PrinttaskdefinitionUpdateTaskParameter parameter)
        {
            return await this.SendAsync<PrinttaskdefinitionUpdateTaskParameter, PrinttaskdefinitionUpdateTaskResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskdefinitionUpdateTaskResponse> PrinttaskdefinitionUpdateTaskAsync(PrinttaskdefinitionUpdateTaskParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttaskdefinitionUpdateTaskParameter, PrinttaskdefinitionUpdateTaskResponse>(parameter, cancellationToken);
        }
    }
}
