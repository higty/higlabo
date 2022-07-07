using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissionGrantParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Shares_EncodedSharingUrl_Permission_Grant,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Shares_EncodedSharingUrl_Permission_Grant: return $"/shares/{EncodedSharingUrl}/permission/grant";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DriveRecipient[]? Recipients { get; set; }
        public String[]? Roles { get; set; }
        public string EncodedSharingUrl { get; set; }
    }
    public partial class PermissionGrantResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/permission?view=graph-rest-1.0
        /// </summary>
        public partial class Permission
        {
            public string? Id { get; set; }
            public SharePointIdentitySet? GrantedToV2 { get; set; }
            public SharePointIdentitySet[]? GrantedToIdentitiesV2 { get; set; }
            public SharingInvitation? Invitation { get; set; }
            public ItemReference? InheritedFrom { get; set; }
            public SharingLink? Link { get; set; }
            public string[]? Roles { get; set; }
            public string? ShareId { get; set; }
            public DateTimeOffset? ExpirationDateTime { get; set; }
            public bool? HasPassword { get; set; }
        }

        public Permission[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync()
        {
            var p = new PermissionGrantParameter();
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync(CancellationToken cancellationToken)
        {
            var p = new PermissionGrantParameter();
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync(PermissionGrantParameter parameter)
        {
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync(PermissionGrantParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(parameter, cancellationToken);
        }
    }
}
