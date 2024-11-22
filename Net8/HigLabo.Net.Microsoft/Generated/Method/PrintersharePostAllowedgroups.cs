using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
/// </summary>
public partial class PrinterSharePostAllowedGroupsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterId { get; set; }
        public string? PrinterShareId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Printers_PrinterId_Shares_PrinterShareId_AllowedGroups_ref: return $"/print/printers/{PrinterId}/shares/{PrinterShareId}/allowedGroups/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_Printers_PrinterId_Shares_PrinterShareId_AllowedGroups_ref,
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
public partial class PrinterSharePostAllowedGroupsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedGroupsResponse> PrinterSharePostAllowedGroupsAsync()
    {
        var p = new PrinterSharePostAllowedGroupsParameter();
        return await this.SendAsync<PrinterSharePostAllowedGroupsParameter, PrinterSharePostAllowedGroupsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedGroupsResponse> PrinterSharePostAllowedGroupsAsync(CancellationToken cancellationToken)
    {
        var p = new PrinterSharePostAllowedGroupsParameter();
        return await this.SendAsync<PrinterSharePostAllowedGroupsParameter, PrinterSharePostAllowedGroupsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedGroupsResponse> PrinterSharePostAllowedGroupsAsync(PrinterSharePostAllowedGroupsParameter parameter)
    {
        return await this.SendAsync<PrinterSharePostAllowedGroupsParameter, PrinterSharePostAllowedGroupsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedGroupsResponse> PrinterSharePostAllowedGroupsAsync(PrinterSharePostAllowedGroupsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrinterSharePostAllowedGroupsParameter, PrinterSharePostAllowedGroupsResponse>(parameter, cancellationToken);
    }
}
