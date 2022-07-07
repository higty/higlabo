using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/accessPackages/filterByCurrentUser";
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
    public partial class AccesspackageFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackage?view=graph-rest-1.0
        /// </summary>
        public partial class AccessPackage
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsHidden { get; set; }
            public DateTimeOffset? ModifiedDateTime { get; set; }
        }

        public AccessPackage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentuserResponse> AccesspackageFilterbycurrentuserAsync()
        {
            var p = new AccesspackageFilterbycurrentuserParameter();
            return await this.SendAsync<AccesspackageFilterbycurrentuserParameter, AccesspackageFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentuserResponse> AccesspackageFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageFilterbycurrentuserParameter();
            return await this.SendAsync<AccesspackageFilterbycurrentuserParameter, AccesspackageFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentuserResponse> AccesspackageFilterbycurrentuserAsync(AccesspackageFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<AccesspackageFilterbycurrentuserParameter, AccesspackageFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageFilterbycurrentuserResponse> AccesspackageFilterbycurrentuserAsync(AccesspackageFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageFilterbycurrentuserParameter, AccesspackageFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
