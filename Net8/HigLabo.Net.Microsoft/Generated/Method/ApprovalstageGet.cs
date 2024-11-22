using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/approvalstage-get?view=graph-rest-1.0
/// </summary>
public partial class ApprovalstageGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessPackageAssignmentRequestId { get; set; }
        public string? ApprovalStageId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId_Stages_ApprovalStageId: return $"/identityGovernance/entitlementManagement/accessPackageAssignmentApprovals/{AccessPackageAssignmentRequestId}/stages/{ApprovalStageId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId_Stages_ApprovalStageId,
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
public partial class ApprovalstageGetResponse : RestApiResponse
{
    public bool? AssignedToMe { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? Justification { get; set; }
    public string? ReviewResult { get; set; }
    public Identity? ReviewedBy { get; set; }
    public DateTimeOffset? ReviewedDateTime { get; set; }
    public string? Status { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/approvalstage-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approvalstage-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalstageGetResponse> ApprovalstageGetAsync()
    {
        var p = new ApprovalstageGetParameter();
        return await this.SendAsync<ApprovalstageGetParameter, ApprovalstageGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approvalstage-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalstageGetResponse> ApprovalstageGetAsync(CancellationToken cancellationToken)
    {
        var p = new ApprovalstageGetParameter();
        return await this.SendAsync<ApprovalstageGetParameter, ApprovalstageGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approvalstage-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalstageGetResponse> ApprovalstageGetAsync(ApprovalstageGetParameter parameter)
    {
        return await this.SendAsync<ApprovalstageGetParameter, ApprovalstageGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approvalstage-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalstageGetResponse> ApprovalstageGetAsync(ApprovalstageGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApprovalstageGetParameter, ApprovalstageGetResponse>(parameter, cancellationToken);
    }
}
