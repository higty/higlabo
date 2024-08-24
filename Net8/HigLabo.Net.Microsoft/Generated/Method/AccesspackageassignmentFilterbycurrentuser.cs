using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/assignments/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Assignments_FilterByCurrentUser,
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
    public partial class AccessPackageAssignmentFilterbycurrentUserResponse : RestApiResponse<AccessPackageAssignment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentFilterbycurrentUserResponse> AccessPackageAssignmentFilterbycurrentUserAsync()
        {
            var p = new AccessPackageAssignmentFilterbycurrentUserParameter();
            return await this.SendAsync<AccessPackageAssignmentFilterbycurrentUserParameter, AccessPackageAssignmentFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentFilterbycurrentUserResponse> AccessPackageAssignmentFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageAssignmentFilterbycurrentUserParameter();
            return await this.SendAsync<AccessPackageAssignmentFilterbycurrentUserParameter, AccessPackageAssignmentFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentFilterbycurrentUserResponse> AccessPackageAssignmentFilterbycurrentUserAsync(AccessPackageAssignmentFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessPackageAssignmentFilterbycurrentUserParameter, AccessPackageAssignmentFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentFilterbycurrentUserResponse> AccessPackageAssignmentFilterbycurrentUserAsync(AccessPackageAssignmentFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageAssignmentFilterbycurrentUserParameter, AccessPackageAssignmentFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessPackageAssignment> AccessPackageAssignmentFilterbycurrentUserEnumerateAsync(AccessPackageAssignmentFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessPackageAssignmentFilterbycurrentUserParameter, AccessPackageAssignmentFilterbycurrentUserResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessPackageAssignment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
