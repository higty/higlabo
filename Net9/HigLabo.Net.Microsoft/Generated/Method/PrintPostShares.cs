using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
/// </summary>
public partial class PrintPostSharesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Shares: return $"/print/shares";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_Shares,
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
    public Printer? Printer { get; set; }
    public string? DisplayName { get; set; }
    public bool? AllowAllUsers { get; set; }
    public PrinterCapabilities? Capabilities { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public PrinterDefaults? Defaults { get; set; }
    public string? Id { get; set; }
    public bool? IsAcceptingJobs { get; set; }
    public PrinterLocation? Location { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public PrinterStatus? Status { get; set; }
    public User[]? AllowedUsers { get; set; }
    public Group? AllowedGroups { get; set; }
    public PrintJob[]? Jobs { get; set; }
}
public partial class PrintPostSharesResponse : RestApiResponse
{
    public bool? AllowAllUsers { get; set; }
    public PrinterCapabilities? Capabilities { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public PrinterDefaults? Defaults { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsAcceptingJobs { get; set; }
    public PrinterLocation? Location { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public PrinterStatus? Status { get; set; }
    public Printer? Printer { get; set; }
    public User[]? AllowedUsers { get; set; }
    public Group? AllowedGroups { get; set; }
    public PrintJob[]? Jobs { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostSharesResponse> PrintPostSharesAsync()
    {
        var p = new PrintPostSharesParameter();
        return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostSharesResponse> PrintPostSharesAsync(CancellationToken cancellationToken)
    {
        var p = new PrintPostSharesParameter();
        return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostSharesResponse> PrintPostSharesAsync(PrintPostSharesParameter parameter)
    {
        return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostSharesResponse> PrintPostSharesAsync(PrintPostSharesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(parameter, cancellationToken);
    }
}
