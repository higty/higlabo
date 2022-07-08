using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
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
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            IsHidden,
            ModifiedDateTime,
            AssignmentPolicies,
            Catalog,
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
    public partial class AccesspackageFilterbycurrentUserResponse : RestApiResponse
    {
        public AccessPackage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentUserResponse> AccesspackageFilterbycurrentUserAsync()
        {
            var p = new AccesspackageFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageFilterbycurrentUserParameter, AccesspackageFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentUserResponse> AccesspackageFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageFilterbycurrentUserParameter, AccesspackageFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentUserResponse> AccesspackageFilterbycurrentUserAsync(AccesspackageFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccesspackageFilterbycurrentUserParameter, AccesspackageFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentUserResponse> AccesspackageFilterbycurrentUserAsync(AccesspackageFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageFilterbycurrentUserParameter, AccesspackageFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
