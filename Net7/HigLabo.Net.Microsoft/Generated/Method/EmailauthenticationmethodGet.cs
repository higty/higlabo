using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class EmailauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Authentication_EmailMethods_Id: return $"/me/authentication/emailMethods/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_EmailMethods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/emailMethods/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_EmailMethods_Id,
            Users_IdOrUserPrincipalName_Authentication_EmailMethods_Id,
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
    public partial class EmailauthenticationmethodGetResponse : RestApiResponse
    {
        public string? EmailAddress { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodGetResponse> EmailauthenticationmethodGetAsync()
        {
            var p = new EmailauthenticationmethodGetParameter();
            return await this.SendAsync<EmailauthenticationmethodGetParameter, EmailauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodGetResponse> EmailauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new EmailauthenticationmethodGetParameter();
            return await this.SendAsync<EmailauthenticationmethodGetParameter, EmailauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodGetResponse> EmailauthenticationmethodGetAsync(EmailauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<EmailauthenticationmethodGetParameter, EmailauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodGetResponse> EmailauthenticationmethodGetAsync(EmailauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmailauthenticationmethodGetParameter, EmailauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
