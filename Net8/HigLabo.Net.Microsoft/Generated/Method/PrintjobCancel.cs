using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
/// </summary>
public partial class PrintJobCancelParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterId { get; set; }
        public string? PrintJobId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId_Cancel: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}/cancel";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_Printers_PrinterId_Jobs_PrintJobId_Cancel,
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
public partial class PrintJobCancelResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintJobCancelResponse> PrintJobCancelAsync()
    {
        var p = new PrintJobCancelParameter();
        return await this.SendAsync<PrintJobCancelParameter, PrintJobCancelResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintJobCancelResponse> PrintJobCancelAsync(CancellationToken cancellationToken)
    {
        var p = new PrintJobCancelParameter();
        return await this.SendAsync<PrintJobCancelParameter, PrintJobCancelResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintJobCancelResponse> PrintJobCancelAsync(PrintJobCancelParameter parameter)
    {
        return await this.SendAsync<PrintJobCancelParameter, PrintJobCancelResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintJobCancelResponse> PrintJobCancelAsync(PrintJobCancelParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrintJobCancelParameter, PrintJobCancelResponse>(parameter, cancellationToken);
    }
}
