using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintDeleteTaskdefinitionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrintTaskDefinitionId { get; set; }

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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync()
        {
            var p = new PrintDeleteTaskdefinitionParameter();
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync(CancellationToken cancellationToken)
        {
            var p = new PrintDeleteTaskdefinitionParameter();
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync(PrintDeleteTaskdefinitionParameter parameter)
        {
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-delete-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintDeleteTaskdefinitionResponse> PrintDeleteTaskdefinitionAsync(PrintDeleteTaskdefinitionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintDeleteTaskdefinitionParameter, PrintDeleteTaskdefinitionResponse>(parameter, cancellationToken);
        }
    }
}
