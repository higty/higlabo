using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
/// </summary>
public partial class PrinterSharePostAllowedUsersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterShareId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Shares_PrinterShareId_AllowedUsers_ref: return $"/print/shares/{PrinterShareId}/allowedUsers/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_Shares_PrinterShareId_AllowedUsers_ref,
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
public partial class PrinterSharePostAllowedUsersResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedUsersResponse> PrinterSharePostAllowedUsersAsync()
    {
        var p = new PrinterSharePostAllowedUsersParameter();
        return await this.SendAsync<PrinterSharePostAllowedUsersParameter, PrinterSharePostAllowedUsersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedUsersResponse> PrinterSharePostAllowedUsersAsync(CancellationToken cancellationToken)
    {
        var p = new PrinterSharePostAllowedUsersParameter();
        return await this.SendAsync<PrinterSharePostAllowedUsersParameter, PrinterSharePostAllowedUsersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedUsersResponse> PrinterSharePostAllowedUsersAsync(PrinterSharePostAllowedUsersParameter parameter)
    {
        return await this.SendAsync<PrinterSharePostAllowedUsersParameter, PrinterSharePostAllowedUsersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterSharePostAllowedUsersResponse> PrinterSharePostAllowedUsersAsync(PrinterSharePostAllowedUsersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrinterSharePostAllowedUsersParameter, PrinterSharePostAllowedUsersResponse>(parameter, cancellationToken);
    }
}
