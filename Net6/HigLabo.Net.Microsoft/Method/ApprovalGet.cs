using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
    /// </summary>
    public partial class ApprovalGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageAssignmentRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId: return $"/identityGovernance/entitlementManagement/accessPackageAssignmentApprovals/{AccessPackageAssignmentRequestId}";
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
            IdentityGovernance_EntitlementManagement_AccessPackageAssignmentApprovals_AccessPackageAssignmentRequestId,
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
    public partial class ApprovalGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public ApprovalStage[]? Stages { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync()
        {
            var p = new ApprovalGetParameter();
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync(CancellationToken cancellationToken)
        {
            var p = new ApprovalGetParameter();
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync(ApprovalGetParameter parameter)
        {
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApprovalGetResponse> ApprovalGetAsync(ApprovalGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApprovalGetParameter, ApprovalGetResponse>(parameter, cancellationToken);
        }
    }
}
