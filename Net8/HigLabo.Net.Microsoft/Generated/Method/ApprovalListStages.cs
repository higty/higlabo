using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
/// </summary>
public partial class ApprovalListStagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessPackageAssignmentRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId_Stages: return $"/identityGovernance/entitlementManagement/accessPackageAssignmentApprovals/{AccessPackageAssignmentRequestId}/stages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId_Stages,
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
public partial class ApprovalListStagesResponse : RestApiResponse<ApprovalStage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalListStagesResponse> ApprovalListStagesAsync()
    {
        var p = new ApprovalListStagesParameter();
        return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalListStagesResponse> ApprovalListStagesAsync(CancellationToken cancellationToken)
    {
        var p = new ApprovalListStagesParameter();
        return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalListStagesResponse> ApprovalListStagesAsync(ApprovalListStagesParameter parameter)
    {
        return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApprovalListStagesResponse> ApprovalListStagesAsync(ApprovalListStagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ApprovalStage> ApprovalListStagesEnumerateAsync(ApprovalListStagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ApprovalStage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
