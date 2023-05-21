using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
    /// </summary>
    public partial class PrintConnectorDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrintConnectorId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Connectors_PrintConnectorId: return $"/print/connectors/{PrintConnectorId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Connectors_PrintConnectorId,
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
    public partial class PrintConnectorDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorDeleteResponse> PrintConnectorDeleteAsync()
        {
            var p = new PrintConnectorDeleteParameter();
            return await this.SendAsync<PrintConnectorDeleteParameter, PrintConnectorDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorDeleteResponse> PrintConnectorDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PrintConnectorDeleteParameter();
            return await this.SendAsync<PrintConnectorDeleteParameter, PrintConnectorDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorDeleteResponse> PrintConnectorDeleteAsync(PrintConnectorDeleteParameter parameter)
        {
            return await this.SendAsync<PrintConnectorDeleteParameter, PrintConnectorDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorDeleteResponse> PrintConnectorDeleteAsync(PrintConnectorDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintConnectorDeleteParameter, PrintConnectorDeleteResponse>(parameter, cancellationToken);
        }
    }
}
