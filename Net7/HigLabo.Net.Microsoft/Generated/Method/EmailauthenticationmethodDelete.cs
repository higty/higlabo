using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class EmailauthenticationmethodDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class EmailauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodDeleteResponse> EmailauthenticationmethodDeleteAsync()
        {
            var p = new EmailauthenticationmethodDeleteParameter();
            return await this.SendAsync<EmailauthenticationmethodDeleteParameter, EmailauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodDeleteResponse> EmailauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EmailauthenticationmethodDeleteParameter();
            return await this.SendAsync<EmailauthenticationmethodDeleteParameter, EmailauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodDeleteResponse> EmailauthenticationmethodDeleteAsync(EmailauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<EmailauthenticationmethodDeleteParameter, EmailauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodDeleteResponse> EmailauthenticationmethodDeleteAsync(EmailauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmailauthenticationmethodDeleteParameter, EmailauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
