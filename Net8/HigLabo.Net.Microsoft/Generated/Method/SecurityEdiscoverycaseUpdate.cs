using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-update?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycaseUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId,
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
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? ExternalId { get; set; }
}
public partial class SecurityEDiscoverycaseUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycaseUpdateResponse> SecurityEDiscoverycaseUpdateAsync()
    {
        var p = new SecurityEDiscoverycaseUpdateParameter();
        return await this.SendAsync<SecurityEDiscoverycaseUpdateParameter, SecurityEDiscoverycaseUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycaseUpdateResponse> SecurityEDiscoverycaseUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycaseUpdateParameter();
        return await this.SendAsync<SecurityEDiscoverycaseUpdateParameter, SecurityEDiscoverycaseUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycaseUpdateResponse> SecurityEDiscoverycaseUpdateAsync(SecurityEDiscoverycaseUpdateParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycaseUpdateParameter, SecurityEDiscoverycaseUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycaseUpdateResponse> SecurityEDiscoverycaseUpdateAsync(SecurityEDiscoverycaseUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycaseUpdateParameter, SecurityEDiscoverycaseUpdateResponse>(parameter, cancellationToken);
    }
}
