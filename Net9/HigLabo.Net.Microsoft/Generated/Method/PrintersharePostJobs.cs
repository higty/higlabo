using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
/// </summary>
public partial class PrinterSharePostJobsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterShareId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Shares_PrinterShareId_Jobs: return $"/print/shares/{PrinterShareId}/jobs";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_Shares_PrinterShareId_Jobs,
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
    public PrintJobConfiguration? Configuration { get; set; }
    public UserIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Boolean? IsFetchable { get; set; }
    public String? RedirectedFrom { get; set; }
    public String? RedirectedTo { get; set; }
    public PrintJobStatus? Status { get; set; }
    public PrintDocument[]? Documents { get; set; }
    public PrintTask[]? Tasks { get; set; }
}
public partial class PrinterSharePostJobsResponse : RestApiResponse
{
    public PrintJobConfiguration? Configuration { get; set; }
    public UserIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Boolean? IsFetchable { get; set; }
    public String? RedirectedFrom { get; set; }
    public String? RedirectedTo { get; set; }
    public PrintJobStatus? Status { get; set; }
    public PrintDocument[]? Documents { get; set; }
    public PrintTask[]? Tasks { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostJobsResponse> PrinterSharePostJobsAsync()
    {
        var p = new PrinterSharePostJobsParameter();
        return await this.SendAsync<PrinterSharePostJobsParameter, PrinterSharePostJobsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostJobsResponse> PrinterSharePostJobsAsync(CancellationToken cancellationToken)
    {
        var p = new PrinterSharePostJobsParameter();
        return await this.SendAsync<PrinterSharePostJobsParameter, PrinterSharePostJobsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostJobsResponse> PrinterSharePostJobsAsync(PrinterSharePostJobsParameter parameter)
    {
        return await this.SendAsync<PrinterSharePostJobsParameter, PrinterSharePostJobsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostJobsResponse> PrinterSharePostJobsAsync(PrinterSharePostJobsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrinterSharePostJobsParameter, PrinterSharePostJobsResponse>(parameter, cancellationToken);
    }
}
