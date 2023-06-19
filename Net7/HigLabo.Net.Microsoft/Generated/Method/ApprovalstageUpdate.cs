using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approvalstage-update?view=graph-rest-1.0
    /// </summary>
    public partial class ApprovalstageUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? ReviewResult { get; set; }
        public string? Justification { get; set; }
    }
    public partial class ApprovalstageUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approvalstage-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approvalstage-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalstageUpdateResponse> ApprovalstageUpdateAsync()
        {
            var p = new ApprovalstageUpdateParameter();
            return await this.SendAsync<ApprovalstageUpdateParameter, ApprovalstageUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approvalstage-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalstageUpdateResponse> ApprovalstageUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ApprovalstageUpdateParameter();
            return await this.SendAsync<ApprovalstageUpdateParameter, ApprovalstageUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approvalstage-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalstageUpdateResponse> ApprovalstageUpdateAsync(ApprovalstageUpdateParameter parameter)
        {
            return await this.SendAsync<ApprovalstageUpdateParameter, ApprovalstageUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approvalstage-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalstageUpdateResponse> ApprovalstageUpdateAsync(ApprovalstageUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApprovalstageUpdateParameter, ApprovalstageUpdateResponse>(parameter, cancellationToken);
        }
    }
}
