using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications: return $"/applications";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AddIns,
            Api,
            AppId,
            ApplicationTemplateId,
            AppRoles,
            Certification,
            CreatedDateTime,
            DeletedDateTime,
            Description,
            DisabledByMicrosoftStatus,
            DisplayName,
            GroupMembershipClaims,
            Id,
            IdentifierUris,
            Info,
            IsDeviceOnlyAuthSupported,
            IsFallbackPublicClient,
            KeyCredentials,
            Logo,
            Notes,
            Oauth2RequiredPostResponse,
            OptionalClaims,
            ParentalControlSettings,
            PasswordCredentials,
            PublicClient,
            PublisherDomain,
            RequestSignatureVerification,
            RequiredResourceAccess,
            SamlMetadataUrl,
            ServiceManagementReference,
            SignInAudience,
            Spa,
            Tags,
            TokenEncryptionKeyId,
            VerifiedPublisher,
            Web,
            AppManagementPolicies,
            CreatedOnBehalfOf,
            ExtensionProperties,
            FederatedIdentityCredentials,
            Owners,
        }
        public enum ApiPath
        {
            Applications,
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
    public partial class ApplicationListResponse : RestApiResponse
    {
        public Application[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync()
        {
            var p = new ApplicationListParameter();
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListParameter();
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync(ApplicationListParameter parameter)
        {
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync(ApplicationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(parameter, cancellationToken);
        }
    }
}
