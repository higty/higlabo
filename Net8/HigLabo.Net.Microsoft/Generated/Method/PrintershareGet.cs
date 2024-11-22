using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
/// </summary>
public partial class PrinterShareGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterShareId { get; set; }
        public string? PrinterId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Shares_PrinterShareId: return $"/print/shares/{PrinterShareId}";
                case ApiPath.Print_Printers_PrinterId_Shares_PrinterShareId: return $"/print/printers/{PrinterId}/shares/{PrinterShareId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Print_Shares_PrinterShareId,
        Print_Printers_PrinterId_Shares_PrinterShareId,
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
public partial class PrinterShareGetResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareGetResponse> PrinterShareGetAsync()
    {
        var p = new PrinterShareGetParameter();
        return await this.SendAsync<PrinterShareGetParameter, PrinterShareGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareGetResponse> PrinterShareGetAsync(CancellationToken cancellationToken)
    {
        var p = new PrinterShareGetParameter();
        return await this.SendAsync<PrinterShareGetParameter, PrinterShareGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareGetResponse> PrinterShareGetAsync(PrinterShareGetParameter parameter)
    {
        return await this.SendAsync<PrinterShareGetParameter, PrinterShareGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareGetResponse> PrinterShareGetAsync(PrinterShareGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrinterShareGetParameter, PrinterShareGetResponse>(parameter, cancellationToken);
    }
}
