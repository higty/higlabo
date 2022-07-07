using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementPostAccesspackagesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages: return $"/identityGovernance/entitlementManagement/accessPackages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool? IsHidden { get; set; }
    }
    public partial class EntitlementmanagementPostAccesspackagesResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHidden { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAccesspackagesResponse> EntitlementmanagementPostAccesspackagesAsync()
        {
            var p = new EntitlementmanagementPostAccesspackagesParameter();
            return await this.SendAsync<EntitlementmanagementPostAccesspackagesParameter, EntitlementmanagementPostAccesspackagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAccesspackagesResponse> EntitlementmanagementPostAccesspackagesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementPostAccesspackagesParameter();
            return await this.SendAsync<EntitlementmanagementPostAccesspackagesParameter, EntitlementmanagementPostAccesspackagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAccesspackagesResponse> EntitlementmanagementPostAccesspackagesAsync(EntitlementmanagementPostAccesspackagesParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementPostAccesspackagesParameter, EntitlementmanagementPostAccesspackagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAccesspackagesResponse> EntitlementmanagementPostAccesspackagesAsync(EntitlementmanagementPostAccesspackagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementPostAccesspackagesParameter, EntitlementmanagementPostAccesspackagesResponse>(parameter, cancellationToken);
        }
    }
}
