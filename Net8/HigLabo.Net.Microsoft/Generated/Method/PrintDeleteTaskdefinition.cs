using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class PrintDeleteTaskdefinitionParameter : IRestApiParameter
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
    public partial class PrintDeleteTaskdefinitionResponse : RestApiResponse
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
        public async ValueTask<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync()
        {
            var p = new PrintDeleteTaskdefinitionParameter();
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync(CancellationToken cancellationToken)
        {
            var p = new PrintDeleteTaskdefinitionParameter();
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync(PrintDeleteTaskdefinitionParameter parameter)
        {
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync(PrintDeleteTaskdefinitionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(parameter, cancellationToken);
        }
    }
}
