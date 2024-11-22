using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoveryReviewtagUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoveryReviewTagId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_EdiscoveryReviewTagId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/tags/{EdiscoveryReviewTagId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum SecurityEDiscoveryReviewtagUpdateParameterSecurityChildSelectability
    {
        One,
        Many,
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_EdiscoveryReviewTagId,
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
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public SecurityEDiscoveryReviewtagUpdateParameterSecurityChildSelectability ChildSelectability { get; set; }
}
public partial class SecurityEDiscoveryReviewtagUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagUpdateResponse> SecurityEDiscoveryReviewtagUpdateAsync()
    {
        var p = new SecurityEDiscoveryReviewtagUpdateParameter();
        return await this.SendAsync<SecurityEDiscoveryReviewtagUpdateParameter, SecurityEDiscoveryReviewtagUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagUpdateResponse> SecurityEDiscoveryReviewtagUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoveryReviewtagUpdateParameter();
        return await this.SendAsync<SecurityEDiscoveryReviewtagUpdateParameter, SecurityEDiscoveryReviewtagUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagUpdateResponse> SecurityEDiscoveryReviewtagUpdateAsync(SecurityEDiscoveryReviewtagUpdateParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoveryReviewtagUpdateParameter, SecurityEDiscoveryReviewtagUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagUpdateResponse> SecurityEDiscoveryReviewtagUpdateAsync(SecurityEDiscoveryReviewtagUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoveryReviewtagUpdateParameter, SecurityEDiscoveryReviewtagUpdateResponse>(parameter, cancellationToken);
    }
}
