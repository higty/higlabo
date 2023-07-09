using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printconnector-update?view=graph-rest-1.0
    /// </summary>
    public partial class PrintConnectorUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class PrintConnectorUpdateResponse : RestApiResponse
    {
        public string? AppVersion { get; set; }
        public string? DisplayName { get; set; }
        public string? FullyQualifiedDomainName { get; set; }
        public string? Id { get; set; }
        public PrinterLocation? Location { get; set; }
        public string? OperatingSystem { get; set; }
        public UserIdentity? RegisteredBy { get; set; }
        public DateTimeOffset? RegisteredDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printconnector-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintConnectorUpdateResponse> PrintConnectorUpdateAsync()
        {
            var p = new PrintConnectorUpdateParameter();
            return await this.SendAsync<PrintConnectorUpdateParameter, PrintConnectorUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintConnectorUpdateResponse> PrintConnectorUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PrintConnectorUpdateParameter();
            return await this.SendAsync<PrintConnectorUpdateParameter, PrintConnectorUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintConnectorUpdateResponse> PrintConnectorUpdateAsync(PrintConnectorUpdateParameter parameter)
        {
            return await this.SendAsync<PrintConnectorUpdateParameter, PrintConnectorUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printconnector-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintConnectorUpdateResponse> PrintConnectorUpdateAsync(PrintConnectorUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintConnectorUpdateParameter, PrintConnectorUpdateResponse>(parameter, cancellationToken);
        }
    }
}
