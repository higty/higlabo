using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id: return $"/applications/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public ApiApplication? Api { get; set; }
        public AppRole[]? AppRoles { get; set; }
        public string? DisplayName { get; set; }
        public string? GroupMembershipClaims { get; set; }
        public String[]? IdentifierUris { get; set; }
        public InformationalUrl? Info { get; set; }
        public bool? IsFallbackPublicClient { get; set; }
        public KeyCredential[]? KeyCredentials { get; set; }
        public Stream? Logo { get; set; }
        public OptionalClaims? OptionalClaims { get; set; }
        public ParentalControlSettings? ParentalControlSettings { get; set; }
        public PublicClientApplication? PublicClient { get; set; }
        public RequiredResourceAccess[]? RequiredResourceAccess { get; set; }
        public string? SignInAudience { get; set; }
        public SpaApplication? Spa { get; set; }
        public String[]? Tags { get; set; }
        public string? TokenEncryptionKeyId { get; set; }
        public WebApplication? Web { get; set; }
    }
    public partial class ApplicationUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUpdateResponse> ApplicationUpdateAsync()
        {
            var p = new ApplicationUpdateParameter();
            return await this.SendAsync<ApplicationUpdateParameter, ApplicationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUpdateResponse> ApplicationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationUpdateParameter();
            return await this.SendAsync<ApplicationUpdateParameter, ApplicationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUpdateResponse> ApplicationUpdateAsync(ApplicationUpdateParameter parameter)
        {
            return await this.SendAsync<ApplicationUpdateParameter, ApplicationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUpdateResponse> ApplicationUpdateAsync(ApplicationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationUpdateParameter, ApplicationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
