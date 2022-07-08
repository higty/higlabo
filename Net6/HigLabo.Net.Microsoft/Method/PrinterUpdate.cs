using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class PrinterUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterUpdateResponse> PrinterUpdateAsync()
        {
            var p = new PrinterUpdateParameter();
            return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterUpdateResponse> PrinterUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterUpdateParameter();
            return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterUpdateResponse> PrinterUpdateAsync(PrinterUpdateParameter parameter)
        {
            return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterUpdateResponse> PrinterUpdateAsync(PrinterUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(parameter, cancellationToken);
        }
    }
}
