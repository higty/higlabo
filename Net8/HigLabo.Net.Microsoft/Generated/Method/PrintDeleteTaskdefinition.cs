using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class PrintDeleteTaskDefinitionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrintTaskDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_TaskDefinitions_PrintTaskDefinitionId: return $"/print/taskDefinitions/{PrintTaskDefinitionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_TaskDefinitions_PrintTaskDefinitionId,
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
    public partial class PrintDeleteTaskDefinitionResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintDeleteTaskDefinitionResponse> PrintDeleteTaskDefinitionAsync()
        {
            var p = new PrintDeleteTaskDefinitionParameter();
            return await this.SendAsync<PrintDeleteTaskDefinitionParameter, PrintDeleteTaskDefinitionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintDeleteTaskDefinitionResponse> PrintDeleteTaskDefinitionAsync(CancellationToken cancellationToken)
        {
            var p = new PrintDeleteTaskDefinitionParameter();
            return await this.SendAsync<PrintDeleteTaskDefinitionParameter, PrintDeleteTaskDefinitionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintDeleteTaskDefinitionResponse> PrintDeleteTaskDefinitionAsync(PrintDeleteTaskDefinitionParameter parameter)
        {
            return await this.SendAsync<PrintDeleteTaskDefinitionParameter, PrintDeleteTaskDefinitionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintDeleteTaskDefinitionResponse> PrintDeleteTaskDefinitionAsync(PrintDeleteTaskDefinitionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintDeleteTaskDefinitionParameter, PrintDeleteTaskDefinitionResponse>(parameter, cancellationToken);
        }
    }
}
