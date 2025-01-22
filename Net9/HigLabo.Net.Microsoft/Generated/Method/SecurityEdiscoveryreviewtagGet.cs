using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-get?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoveryReviewtagGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoveryReviewTagId { get; set; }
        public string? EdiscoveryReviewSetId { get; set; }
        public string? EdiscoveryFileId { get; set; }
        public string? EdiscoveryCasesEdiscoveryCaseId { get; set; }
        public string? ReviewSetsEdiscoveryReviewSetId { get; set; }
        public string? FilesEdiscoveryFileId { get; set; }
        public string? TagsEdiscoveryReviewTagId { get; set; }
        public string? ChildTagsEdiscoveryReviewTagId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_EdiscoveryReviewTagId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/tags/{EdiscoveryReviewTagId}";
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Tags_EdiscoveryReviewTagId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/files/{EdiscoveryFileId}/tags/{EdiscoveryReviewTagId}";
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Tags_EdiscoveryReviewTagId_Parent: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/files/{EdiscoveryFileId}/tags/{EdiscoveryReviewTagId}/parent";
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Tags_EdiscoveryReviewTagId_ChildTags_EdiscoveryReviewTagId: return $"/security/cases/ediscoveryCases/{EdiscoveryCasesEdiscoveryCaseId}/reviewSets/{ReviewSetsEdiscoveryReviewSetId}/files/{FilesEdiscoveryFileId}/tags/{TagsEdiscoveryReviewTagId}/childTags/{ChildTagsEdiscoveryReviewTagId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_EdiscoveryReviewTagId,
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Tags_EdiscoveryReviewTagId,
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Tags_EdiscoveryReviewTagId_Parent,
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Tags_EdiscoveryReviewTagId_ChildTags_EdiscoveryReviewTagId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class SecurityEDiscoveryReviewtagGetResponse : RestApiResponse
{
    public enum EDiscoveryReviewTagSecurityChildSelectability
    {
        One,
        Many,
    }

    public EDiscoveryReviewTagSecurityChildSelectability ChildSelectability { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public EDiscoveryReviewTag[]? ChildTags { get; set; }
    public EDiscoveryReviewTag? Parent { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagGetResponse> SecurityEDiscoveryReviewtagGetAsync()
    {
        var p = new SecurityEDiscoveryReviewtagGetParameter();
        return await this.SendAsync<SecurityEDiscoveryReviewtagGetParameter, SecurityEDiscoveryReviewtagGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagGetResponse> SecurityEDiscoveryReviewtagGetAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoveryReviewtagGetParameter();
        return await this.SendAsync<SecurityEDiscoveryReviewtagGetParameter, SecurityEDiscoveryReviewtagGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagGetResponse> SecurityEDiscoveryReviewtagGetAsync(SecurityEDiscoveryReviewtagGetParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoveryReviewtagGetParameter, SecurityEDiscoveryReviewtagGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoveryReviewtagGetResponse> SecurityEDiscoveryReviewtagGetAsync(SecurityEDiscoveryReviewtagGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoveryReviewtagGetParameter, SecurityEDiscoveryReviewtagGetResponse>(parameter, cancellationToken);
    }
}
