using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
/// </summary>
public partial class PrinterUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterId { get; set; }

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
    public PrinterDefaults? Defaults { get; set; }
    public PrinterLocation? Location { get; set; }
    public string? DisplayName { get; set; }
}
public partial class PrinterUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterUpdateResponse> PrinterUpdateAsync()
    {
        var p = new PrinterUpdateParameter();
        return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterUpdateResponse> PrinterUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new PrinterUpdateParameter();
        return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterUpdateResponse> PrinterUpdateAsync(PrinterUpdateParameter parameter)
    {
        return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterUpdateResponse> PrinterUpdateAsync(PrinterUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrinterUpdateParameter, PrinterUpdateResponse>(parameter, cancellationToken);
    }
}
