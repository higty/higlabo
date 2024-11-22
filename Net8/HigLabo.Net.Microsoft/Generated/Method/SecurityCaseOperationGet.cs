using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-caseoperation-get?view=graph-rest-1.0
/// </summary>
public partial class SecurityCaseOperationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? CaseOperationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Operations_CaseOperationId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/operations/{CaseOperationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Operations_CaseOperationId,
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
public partial class SecurityCaseOperationGetResponse : RestApiResponse
{
    public enum CaseOperationSecurityCaseAction
    {
        AddToReviewSet,
        ApplyTags,
        ContentExport,
        ConvertToPdf,
        EstimateStatistics,
        PurgeData,
    }
    public enum CaseOperationSecurityCaseOperationStatus
    {
        NotStarted,
        SubmissionFailed,
        Running,
        Succeeded,
        PartiallySucceeded,
        Failed,
    }

    public CaseOperation? Action { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Int32? PercentProgress { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public CaseOperationSecurityCaseOperationStatus Status { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-caseoperation-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-caseoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCaseOperationGetResponse> SecurityCaseOperationGetAsync()
    {
        var p = new SecurityCaseOperationGetParameter();
        return await this.SendAsync<SecurityCaseOperationGetParameter, SecurityCaseOperationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-caseoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCaseOperationGetResponse> SecurityCaseOperationGetAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityCaseOperationGetParameter();
        return await this.SendAsync<SecurityCaseOperationGetParameter, SecurityCaseOperationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-caseoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCaseOperationGetResponse> SecurityCaseOperationGetAsync(SecurityCaseOperationGetParameter parameter)
    {
        return await this.SendAsync<SecurityCaseOperationGetParameter, SecurityCaseOperationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-caseoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCaseOperationGetResponse> SecurityCaseOperationGetAsync(SecurityCaseOperationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityCaseOperationGetParameter, SecurityCaseOperationGetResponse>(parameter, cancellationToken);
    }
}
