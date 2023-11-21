using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class TemporaryAccesspassauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TemporaryAccessPassAuthenticationMethodId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId: return $"/me/authentication/temporaryAccessPassMethods/{TemporaryAccessPassAuthenticationMethodId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods/{TemporaryAccessPassAuthenticationMethodId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Id,
            IsUsable,
            IsUsableOnce,
            LifetimeInMinutes,
            MethodUsabilityReason,
            StartDateTime,
            TemporaryAccessPass,
        }
        public enum ApiPath
        {
            Me_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId,
            Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId,
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
    public partial class TemporaryAccesspassauthenticationmethodGetResponse : RestApiResponse
    {
        public TemporaryAccessPassAuthenticationMethod[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodGetResponse> TemporaryAccesspassauthenticationmethodGetAsync()
        {
            var p = new TemporaryAccesspassauthenticationmethodGetParameter();
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodGetParameter, TemporaryAccesspassauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodGetResponse> TemporaryAccesspassauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new TemporaryAccesspassauthenticationmethodGetParameter();
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodGetParameter, TemporaryAccesspassauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodGetResponse> TemporaryAccesspassauthenticationmethodGetAsync(TemporaryAccesspassauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodGetParameter, TemporaryAccesspassauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodGetResponse> TemporaryAccesspassauthenticationmethodGetAsync(TemporaryAccesspassauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodGetParameter, TemporaryAccesspassauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
