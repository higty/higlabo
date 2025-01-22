using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycasePostReviewsetsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets,
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
    public string? DisplayName { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public EDiscoveryReviewSetQuery[]? Queries { get; set; }
}
public partial class SecurityEDiscoverycasePostReviewsetsResponse : RestApiResponse
{
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public EDiscoveryReviewSetQuery[]? Queries { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostReviewsetsResponse> SecurityEDiscoverycasePostReviewsetsAsync()
    {
        var p = new SecurityEDiscoverycasePostReviewsetsParameter();
        return await this.SendAsync<SecurityEDiscoverycasePostReviewsetsParameter, SecurityEDiscoverycasePostReviewsetsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostReviewsetsResponse> SecurityEDiscoverycasePostReviewsetsAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycasePostReviewsetsParameter();
        return await this.SendAsync<SecurityEDiscoverycasePostReviewsetsParameter, SecurityEDiscoverycasePostReviewsetsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostReviewsetsResponse> SecurityEDiscoverycasePostReviewsetsAsync(SecurityEDiscoverycasePostReviewsetsParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycasePostReviewsetsParameter, SecurityEDiscoverycasePostReviewsetsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostReviewsetsResponse> SecurityEDiscoverycasePostReviewsetsAsync(SecurityEDiscoverycasePostReviewsetsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycasePostReviewsetsParameter, SecurityEDiscoverycasePostReviewsetsResponse>(parameter, cancellationToken);
    }
}
