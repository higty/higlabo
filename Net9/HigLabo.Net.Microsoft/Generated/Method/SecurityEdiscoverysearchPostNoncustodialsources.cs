using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-noncustodialsources?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverysearchPostNoncustodialsourcesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoverySearchId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources_ref: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/noncustodialSources/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources_ref,
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
public partial class SecurityEDiscoverysearchPostNoncustodialsourcesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-noncustodialsources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchPostNoncustodialsourcesResponse> SecurityEDiscoverysearchPostNoncustodialsourcesAsync()
    {
        var p = new SecurityEDiscoverysearchPostNoncustodialsourcesParameter();
        return await this.SendAsync<SecurityEDiscoverysearchPostNoncustodialsourcesParameter, SecurityEDiscoverysearchPostNoncustodialsourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchPostNoncustodialsourcesResponse> SecurityEDiscoverysearchPostNoncustodialsourcesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverysearchPostNoncustodialsourcesParameter();
        return await this.SendAsync<SecurityEDiscoverysearchPostNoncustodialsourcesParameter, SecurityEDiscoverysearchPostNoncustodialsourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchPostNoncustodialsourcesResponse> SecurityEDiscoverysearchPostNoncustodialsourcesAsync(SecurityEDiscoverysearchPostNoncustodialsourcesParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverysearchPostNoncustodialsourcesParameter, SecurityEDiscoverysearchPostNoncustodialsourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchPostNoncustodialsourcesResponse> SecurityEDiscoverysearchPostNoncustodialsourcesAsync(SecurityEDiscoverysearchPostNoncustodialsourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverysearchPostNoncustodialsourcesParameter, SecurityEDiscoverysearchPostNoncustodialsourcesResponse>(parameter, cancellationToken);
    }
}
