using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class PrintUpdateTaskdefinitionParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? CreatedBy { get; set; }
    }
    public partial class PrintUpdateTaskdefinitionResponse : RestApiResponse
    {
        public AppIdentity? CreatedBy { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintUpdateTaskdefinitionResponse> PrintUpdateTaskdefinitionAsync()
        {
            var p = new PrintUpdateTaskdefinitionParameter();
            return await this.SendAsync<PrintUpdateTaskdefinitionParameter, PrintUpdateTaskdefinitionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintUpdateTaskdefinitionResponse> PrintUpdateTaskdefinitionAsync(CancellationToken cancellationToken)
        {
            var p = new PrintUpdateTaskdefinitionParameter();
            return await this.SendAsync<PrintUpdateTaskdefinitionParameter, PrintUpdateTaskdefinitionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintUpdateTaskdefinitionResponse> PrintUpdateTaskdefinitionAsync(PrintUpdateTaskdefinitionParameter parameter)
        {
            return await this.SendAsync<PrintUpdateTaskdefinitionParameter, PrintUpdateTaskdefinitionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintUpdateTaskdefinitionResponse> PrintUpdateTaskdefinitionAsync(PrintUpdateTaskdefinitionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintUpdateTaskdefinitionParameter, PrintUpdateTaskdefinitionResponse>(parameter, cancellationToken);
        }
    }
}
