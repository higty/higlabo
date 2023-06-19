using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-create?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterCreateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_Create: return $"/print/printers/create";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_Create,
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
        public string? DisplayName { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? PhysicalDeviceId { get; set; }
        public bool? HasPhysicalDevice { get; set; }
        public PrintCertificateSigningRequest? CertificateSigningRequest { get; set; }
        public string? ConnectorId { get; set; }
        public string? Certificate { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public PrintOperationStatus? Status { get; set; }
        public Printer? Printer { get; set; }
    }
    public partial class PrinterCreateResponse : RestApiResponse
    {
        public string? Certificate { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public PrintOperationStatus? Status { get; set; }
        public Printer? Printer { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-create?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterCreateResponse> PrinterCreateAsync()
        {
            var p = new PrinterCreateParameter();
            return await this.SendAsync<PrinterCreateParameter, PrinterCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterCreateResponse> PrinterCreateAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterCreateParameter();
            return await this.SendAsync<PrinterCreateParameter, PrinterCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterCreateResponse> PrinterCreateAsync(PrinterCreateParameter parameter)
        {
            return await this.SendAsync<PrinterCreateParameter, PrinterCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterCreateResponse> PrinterCreateAsync(PrinterCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterCreateParameter, PrinterCreateResponse>(parameter, cancellationToken);
        }
    }
}
