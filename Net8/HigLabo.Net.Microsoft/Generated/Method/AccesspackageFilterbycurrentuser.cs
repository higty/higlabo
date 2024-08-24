using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/accessPackages/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_FilterByCurrentUser,
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
    public partial class AccessPackageFilterbycurrentUserResponse : RestApiResponse<AccessPackage>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageFilterbycurrentUserResponse> AccessPackageFilterbycurrentUserAsync()
        {
            var p = new AccessPackageFilterbycurrentUserParameter();
            return await this.SendAsync<AccessPackageFilterbycurrentUserParameter, AccessPackageFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageFilterbycurrentUserResponse> AccessPackageFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageFilterbycurrentUserParameter();
            return await this.SendAsync<AccessPackageFilterbycurrentUserParameter, AccessPackageFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageFilterbycurrentUserResponse> AccessPackageFilterbycurrentUserAsync(AccessPackageFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessPackageFilterbycurrentUserParameter, AccessPackageFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageFilterbycurrentUserResponse> AccessPackageFilterbycurrentUserAsync(AccessPackageFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageFilterbycurrentUserParameter, AccessPackageFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessPackage> AccessPackageFilterbycurrentUserEnumerateAsync(AccessPackageFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessPackageFilterbycurrentUserParameter, AccessPackageFilterbycurrentUserResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessPackage>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
