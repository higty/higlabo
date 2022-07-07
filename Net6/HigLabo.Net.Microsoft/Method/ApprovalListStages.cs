using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApprovalListStagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId_Stages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId_Stages: return $"/identityGovernance/entitlementManagement/accessPackageAssignmentApprovals/{AccessPackageAssignmentRequestId}/stages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string AccessPackageAssignmentRequestId { get; set; }
    }
    public partial class ApprovalListStagesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/approvalstage?view=graph-rest-1.0
        /// </summary>
        public partial class ApprovalStage
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

        public ApprovalStage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalListStagesResponse> ApprovalListStagesAsync()
        {
            var p = new ApprovalListStagesParameter();
            return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalListStagesResponse> ApprovalListStagesAsync(CancellationToken cancellationToken)
        {
            var p = new ApprovalListStagesParameter();
            return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalListStagesResponse> ApprovalListStagesAsync(ApprovalListStagesParameter parameter)
        {
            return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalListStagesResponse> ApprovalListStagesAsync(ApprovalListStagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApprovalListStagesParameter, ApprovalListStagesResponse>(parameter, cancellationToken);
        }
    }
}
