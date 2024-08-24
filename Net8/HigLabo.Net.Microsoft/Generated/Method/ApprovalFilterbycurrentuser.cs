using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
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
    public partial class ApprovalFilterbycurrentUserResponse : RestApiResponse<Approval>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync()
        {
            var p = new ApprovalFilterbycurrentUserParameter();
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new ApprovalFilterbycurrentUserParameter();
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync(ApprovalFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApprovalFilterbycurrentUserResponse> ApprovalFilterbycurrentUserAsync(ApprovalFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/approval-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Approval> ApprovalFilterbycurrentUserEnumerateAsync(ApprovalFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ApprovalFilterbycurrentUserParameter, ApprovalFilterbycurrentUserResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Approval>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
