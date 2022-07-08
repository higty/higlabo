using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrinterId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId: return $"/print/printers/{PrinterId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId,
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
    public partial class PrinterDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteResponse> PrinterDeleteAsync()
        {
            var p = new PrinterDeleteParameter();
            return await this.SendAsync<PrinterDeleteParameter, PrinterDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteResponse> PrinterDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterDeleteParameter();
            return await this.SendAsync<PrinterDeleteParameter, PrinterDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteResponse> PrinterDeleteAsync(PrinterDeleteParameter parameter)
        {
            return await this.SendAsync<PrinterDeleteParameter, PrinterDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteResponse> PrinterDeleteAsync(PrinterDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterDeleteParameter, PrinterDeleteResponse>(parameter, cancellationToken);
        }
    }
}
