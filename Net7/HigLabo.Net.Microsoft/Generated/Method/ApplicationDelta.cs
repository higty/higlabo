using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delta?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Delta: return $"/applications/delta";
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
            Applications_Delta,
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
    public partial class ApplicationDeltaResponse : RestApiResponse
    {
        public Application[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationDeltaResponse> ApplicationDeltaAsync()
        {
            var p = new ApplicationDeltaParameter();
            return await this.SendAsync<ApplicationDeltaParameter, ApplicationDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationDeltaResponse> ApplicationDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationDeltaParameter();
            return await this.SendAsync<ApplicationDeltaParameter, ApplicationDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationDeltaResponse> ApplicationDeltaAsync(ApplicationDeltaParameter parameter)
        {
            return await this.SendAsync<ApplicationDeltaParameter, ApplicationDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationDeltaResponse> ApplicationDeltaAsync(ApplicationDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationDeltaParameter, ApplicationDeltaResponse>(parameter, cancellationToken);
        }
    }
}
