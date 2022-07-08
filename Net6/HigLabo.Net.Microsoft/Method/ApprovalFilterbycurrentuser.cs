using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApprovalFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/accessPackageAssignmentApprovals/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Stages,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_FilterByCurrentUser,
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
    public partial class ApprovalFilterbycurrentUserResponse : RestApiResponse
    {
        public Approval[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync()
        {
            var p = new ApprovalFilterbycurrentUserParameter();
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new ApprovalFilterbycurrentUserParameter();
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync(ApprovalFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync(ApprovalFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
