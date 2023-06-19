using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterListConnectorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_Connectors: return $"/print/printers/{PrinterId}/connectors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppVersion,
            DisplayName,
            FullyQualifiedDomainName,
            Id,
            Location,
            OperatingSystem,
            RegisteredBy,
            RegisteredDateTime,
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Connectors,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class PrinterListConnectorsResponse : RestApiResponse
    {
        public PrintConnector[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListConnectorsResponse> PrinterListConnectorsAsync()
        {
            var p = new PrinterListConnectorsParameter();
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListConnectorsResponse> PrinterListConnectorsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterListConnectorsParameter();
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListConnectorsResponse> PrinterListConnectorsAsync(PrinterListConnectorsParameter parameter)
        {
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListConnectorsResponse> PrinterListConnectorsAsync(PrinterListConnectorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(parameter, cancellationToken);
        }
    }
}
