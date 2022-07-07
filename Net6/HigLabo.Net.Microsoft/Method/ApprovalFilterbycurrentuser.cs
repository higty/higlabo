using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApprovalFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/accessPackageAssignmentApprovals/filterByCurrentUser";
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
    }
    public partial class ApprovalFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/approval?view=graph-rest-1.0
        /// </summary>
        public partial class Approval
        {
            public string? Id { get; set; }
        }

        public Approval[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentuserResponse> ApprovalFilterbycurrentuserAsync()
        {
            var p = new ApprovalFilterbycurrentuserParameter();
            return await this.SendAsync<ApprovalFilterbycurrentuserParameter, ApprovalFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentuserResponse> ApprovalFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new ApprovalFilterbycurrentuserParameter();
            return await this.SendAsync<ApprovalFilterbycurrentuserParameter, ApprovalFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentuserResponse> ApprovalFilterbycurrentuserAsync(ApprovalFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<ApprovalFilterbycurrentuserParameter, ApprovalFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentuserResponse> ApprovalFilterbycurrentuserAsync(ApprovalFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApprovalFilterbycurrentuserParameter, ApprovalFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
