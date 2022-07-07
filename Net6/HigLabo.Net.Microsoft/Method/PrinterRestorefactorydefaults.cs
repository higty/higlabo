using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterRestorefactorydefaultsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_RestoreFactoryDefaults,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_RestoreFactoryDefaults: return $"/print/printers/{PrinterId}/restoreFactoryDefaults";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterId { get; set; }
    }
    public partial class PrinterRestorefactorydefaultsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterRestorefactorydefaultsResponse> PrinterRestorefactorydefaultsAsync()
        {
            var p = new PrinterRestorefactorydefaultsParameter();
            return await this.SendAsync<PrinterRestorefactorydefaultsParameter, PrinterRestorefactorydefaultsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterRestorefactorydefaultsResponse> PrinterRestorefactorydefaultsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterRestorefactorydefaultsParameter();
            return await this.SendAsync<PrinterRestorefactorydefaultsParameter, PrinterRestorefactorydefaultsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterRestorefactorydefaultsResponse> PrinterRestorefactorydefaultsAsync(PrinterRestorefactorydefaultsParameter parameter)
        {
            return await this.SendAsync<PrinterRestorefactorydefaultsParameter, PrinterRestorefactorydefaultsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterRestorefactorydefaultsResponse> PrinterRestorefactorydefaultsAsync(PrinterRestorefactorydefaultsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterRestorefactorydefaultsParameter, PrinterRestorefactorydefaultsResponse>(parameter, cancellationToken);
        }
    }
}
