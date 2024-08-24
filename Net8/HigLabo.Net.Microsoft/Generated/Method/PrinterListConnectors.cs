using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

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
    public partial class PrinterListConnectorsResponse : RestApiResponse<PrintConnector>
    {
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
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintConnector> PrinterListConnectorsEnumerateAsync(PrinterListConnectorsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrintConnector>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
