using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/passwordauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class PasswordauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_PasswordMethods_Id: return $"/me/authentication/passwordMethods/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_PasswordMethods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/passwordMethods/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_PasswordMethods_Id,
            Users_IdOrUserPrincipalName_Authentication_PasswordMethods_Id,
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
    public partial class PasswordauthenticationmethodGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Password { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/passwordauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/passwordauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PasswordauthenticationmethodGetResponse> PasswordauthenticationmethodGetAsync()
        {
            var p = new PasswordauthenticationmethodGetParameter();
            return await this.SendAsync<PasswordauthenticationmethodGetParameter, PasswordauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/passwordauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PasswordauthenticationmethodGetResponse> PasswordauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new PasswordauthenticationmethodGetParameter();
            return await this.SendAsync<PasswordauthenticationmethodGetParameter, PasswordauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/passwordauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PasswordauthenticationmethodGetResponse> PasswordauthenticationmethodGetAsync(PasswordauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<PasswordauthenticationmethodGetParameter, PasswordauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/passwordauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PasswordauthenticationmethodGetResponse> PasswordauthenticationmethodGetAsync(PasswordauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PasswordauthenticationmethodGetParameter, PasswordauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
