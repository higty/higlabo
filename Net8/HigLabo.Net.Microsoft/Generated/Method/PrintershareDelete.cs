using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterShareDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId: return $"/print/shares/{PrinterShareId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Shares_PrinterShareId,
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
    public partial class PrinterShareDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareDeleteResponse> PrinterShareDeleteAsync()
        {
            var p = new PrinterShareDeleteParameter();
            return await this.SendAsync<PrinterShareDeleteParameter, PrinterShareDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareDeleteResponse> PrinterShareDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterShareDeleteParameter();
            return await this.SendAsync<PrinterShareDeleteParameter, PrinterShareDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareDeleteResponse> PrinterShareDeleteAsync(PrinterShareDeleteParameter parameter)
        {
            return await this.SendAsync<PrinterShareDeleteParameter, PrinterShareDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareDeleteResponse> PrinterShareDeleteAsync(PrinterShareDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterShareDeleteParameter, PrinterShareDeleteResponse>(parameter, cancellationToken);
        }
    }
}
