using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApprovalGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Id,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId: return $"/identityGovernance/entitlementManagement/accessPackageAssignmentApprovals/{AccessPackageAssignmentRequestId}";
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
    public partial class ApprovalGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync()
        {
            var p = new ApprovalGetParameter();
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync(CancellationToken cancellationToken)
        {
            var p = new ApprovalGetParameter();
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync(ApprovalGetParameter parameter)
        {
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync(ApprovalGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(parameter, cancellationToken);
        }
    }
}
