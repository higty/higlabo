using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-reopen?view=graph-rest-1.0
/// </summary>
public partial class SecurityEdiscoverycaseReopenParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Reopen: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reopen";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Reopen,
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
public partial class SecurityEdiscoverycaseReopenResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-reopen?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-reopen?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverycaseReopenResponse> SecurityEdiscoverycaseReopenAsync()
    {
        var p = new SecurityEdiscoverycaseReopenParameter();
        return await this.SendAsync<SecurityEdiscoverycaseReopenParameter, SecurityEdiscoverycaseReopenResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-reopen?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverycaseReopenResponse> SecurityEdiscoverycaseReopenAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEdiscoverycaseReopenParameter();
        return await this.SendAsync<SecurityEdiscoverycaseReopenParameter, SecurityEdiscoverycaseReopenResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-reopen?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverycaseReopenResponse> SecurityEdiscoverycaseReopenAsync(SecurityEdiscoverycaseReopenParameter parameter)
    {
        return await this.SendAsync<SecurityEdiscoverycaseReopenParameter, SecurityEdiscoverycaseReopenResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-reopen?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverycaseReopenResponse> SecurityEdiscoverycaseReopenAsync(SecurityEdiscoverycaseReopenParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEdiscoverycaseReopenParameter, SecurityEdiscoverycaseReopenResponse>(parameter, cancellationToken);
    }
}
