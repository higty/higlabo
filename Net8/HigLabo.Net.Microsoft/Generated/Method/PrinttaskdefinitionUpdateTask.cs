using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
    /// </summary>
    public partial class PrinttaskDefinitionUpdateTaskParameter : IRestApiParameter
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
    public partial class PrinttaskDefinitionUpdateTaskResponse : RestApiResponse
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
        public async ValueTask<PrinttaskDefinitionUpdateTaskResponse> PrinttaskDefinitionUpdateTaskAsync()
        {
            var p = new PrinttaskDefinitionUpdateTaskParameter();
            return await this.SendAsync<PrinttaskDefinitionUpdateTaskParameter, PrinttaskDefinitionUpdateTaskResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskDefinitionUpdateTaskResponse> PrinttaskDefinitionUpdateTaskAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttaskDefinitionUpdateTaskParameter();
            return await this.SendAsync<PrinttaskDefinitionUpdateTaskParameter, PrinttaskDefinitionUpdateTaskResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskDefinitionUpdateTaskResponse> PrinttaskDefinitionUpdateTaskAsync(PrinttaskDefinitionUpdateTaskParameter parameter)
        {
            return await this.SendAsync<PrinttaskDefinitionUpdateTaskParameter, PrinttaskDefinitionUpdateTaskResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-update-task?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskDefinitionUpdateTaskResponse> PrinttaskDefinitionUpdateTaskAsync(PrinttaskDefinitionUpdateTaskParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttaskDefinitionUpdateTaskParameter, PrinttaskDefinitionUpdateTaskResponse>(parameter, cancellationToken);
        }
    }
}
