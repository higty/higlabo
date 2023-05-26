using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class PrintPostTaskdefinitionsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_TaskDefinitions: return $"/print/taskDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_TaskDefinitions,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public AppIdentity? CreatedBy { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
    public partial class PrintPostTaskdefinitionsResponse : RestApiResponse
    {
        public AppIdentity? CreatedBy { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostTaskdefinitionsResponse> PrintPostTaskdefinitionsAsync()
        {
            var p = new PrintPostTaskdefinitionsParameter();
            return await this.SendAsync<PrintPostTaskdefinitionsParameter, PrintPostTaskdefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostTaskdefinitionsResponse> PrintPostTaskdefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintPostTaskdefinitionsParameter();
            return await this.SendAsync<PrintPostTaskdefinitionsParameter, PrintPostTaskdefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostTaskdefinitionsResponse> PrintPostTaskdefinitionsAsync(PrintPostTaskdefinitionsParameter parameter)
        {
            return await this.SendAsync<PrintPostTaskdefinitionsParameter, PrintPostTaskdefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostTaskdefinitionsResponse> PrintPostTaskdefinitionsAsync(PrintPostTaskdefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintPostTaskdefinitionsParameter, PrintPostTaskdefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
