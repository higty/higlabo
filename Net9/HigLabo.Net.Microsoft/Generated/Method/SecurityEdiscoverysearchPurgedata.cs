using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-purgedata?view=graph-rest-1.0
/// </summary>
public partial class SecurityEdiscoverysearchPurgedataParameter : IRestApiParameter
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
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_PurgeData: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/purgeData";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum SecurityEdiscoverysearchPurgedataParameterSecurityPurgeType
    {
        Recoverable,
        Permanentlydeleted,
        UnknownFutureValue,
    }
    public enum SecurityEdiscoverysearchPurgedataParameterSecurityPurgeAreas
    {
        Mailboxes,
        TeamsMessages,
        UnknownFutureValue,
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_PurgeData,
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
    public SecurityEdiscoverysearchPurgedataParameterSecurityPurgeType PurgeType { get; set; }
    public SecurityEdiscoverysearchPurgedataParameterSecurityPurgeAreas PurgeAreas { get; set; }
}
public partial class SecurityEdiscoverysearchPurgedataResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-purgedata?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-purgedata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverysearchPurgedataResponse> SecurityEdiscoverysearchPurgedataAsync()
    {
        var p = new SecurityEdiscoverysearchPurgedataParameter();
        return await this.SendAsync<SecurityEdiscoverysearchPurgedataParameter, SecurityEdiscoverysearchPurgedataResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-purgedata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverysearchPurgedataResponse> SecurityEdiscoverysearchPurgedataAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEdiscoverysearchPurgedataParameter();
        return await this.SendAsync<SecurityEdiscoverysearchPurgedataParameter, SecurityEdiscoverysearchPurgedataResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-purgedata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverysearchPurgedataResponse> SecurityEdiscoverysearchPurgedataAsync(SecurityEdiscoverysearchPurgedataParameter parameter)
    {
        return await this.SendAsync<SecurityEdiscoverysearchPurgedataParameter, SecurityEdiscoverysearchPurgedataResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-purgedata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEdiscoverysearchPurgedataResponse> SecurityEdiscoverysearchPurgedataAsync(SecurityEdiscoverysearchPurgedataParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEdiscoverysearchPurgedataParameter, SecurityEdiscoverysearchPurgedataResponse>(parameter, cancellationToken);
    }
}
