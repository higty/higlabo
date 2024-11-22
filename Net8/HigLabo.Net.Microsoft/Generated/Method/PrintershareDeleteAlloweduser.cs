using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
/// </summary>
public partial class PrinterShareDeleteAllowedUserParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterShareId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Shares_PrinterShareId_AllowedUsers_UserId_ref: return $"/print/shares/{PrinterShareId}/allowedUsers/{UserId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_Shares_PrinterShareId_AllowedUsers_UserId_ref,
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
public partial class PrinterShareDeleteAllowedUserResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareDeleteAllowedUserResponse> PrinterShareDeleteAllowedUserAsync()
    {
        var p = new PrinterShareDeleteAllowedUserParameter();
        return await this.SendAsync<PrinterShareDeleteAllowedUserParameter, PrinterShareDeleteAllowedUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareDeleteAllowedUserResponse> PrinterShareDeleteAllowedUserAsync(CancellationToken cancellationToken)
    {
        var p = new PrinterShareDeleteAllowedUserParameter();
        return await this.SendAsync<PrinterShareDeleteAllowedUserParameter, PrinterShareDeleteAllowedUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareDeleteAllowedUserResponse> PrinterShareDeleteAllowedUserAsync(PrinterShareDeleteAllowedUserParameter parameter)
    {
        return await this.SendAsync<PrinterShareDeleteAllowedUserParameter, PrinterShareDeleteAllowedUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterShareDeleteAllowedUserResponse> PrinterShareDeleteAllowedUserAsync(PrinterShareDeleteAllowedUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrinterShareDeleteAllowedUserParameter, PrinterShareDeleteAllowedUserResponse>(parameter, cancellationToken);
    }
}
