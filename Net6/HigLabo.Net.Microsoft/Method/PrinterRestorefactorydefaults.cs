using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterReStorefactorydefaultsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_RestoreFactoryDefaults: return $"/print/printers/{PrinterId}/restoreFactoryDefaults";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId_RestoreFactoryDefaults,
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
    }
    public partial class PrinterReStorefactorydefaultsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterReStorefactorydefaultsResponse> PrinterReStorefactorydefaultsAsync()
        {
            var p = new PrinterReStorefactorydefaultsParameter();
            return await this.SendAsync<PrinterReStorefactorydefaultsParameter, PrinterReStorefactorydefaultsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterReStorefactorydefaultsResponse> PrinterReStorefactorydefaultsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterReStorefactorydefaultsParameter();
            return await this.SendAsync<PrinterReStorefactorydefaultsParameter, PrinterReStorefactorydefaultsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterReStorefactorydefaultsResponse> PrinterReStorefactorydefaultsAsync(PrinterReStorefactorydefaultsParameter parameter)
        {
            return await this.SendAsync<PrinterReStorefactorydefaultsParameter, PrinterReStorefactorydefaultsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-restorefactorydefaults?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterReStorefactorydefaultsResponse> PrinterReStorefactorydefaultsAsync(PrinterReStorefactorydefaultsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterReStorefactorydefaultsParameter, PrinterReStorefactorydefaultsResponse>(parameter, cancellationToken);
        }
    }
}
