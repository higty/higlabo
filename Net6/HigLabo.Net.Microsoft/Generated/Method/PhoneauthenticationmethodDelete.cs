using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class PhoneauthenticationmethodDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PhoneMethodId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_PhoneMethods_PhoneMethodId: return $"/me/authentication/phoneMethods/{PhoneMethodId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_PhoneMethods_PhoneMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/phoneMethods/{PhoneMethodId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Authentication_PhoneMethods_PhoneMethodId,
            Users_IdOrUserPrincipalName_Authentication_PhoneMethods_PhoneMethodId,
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
    public partial class PhoneauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PhoneauthenticationmethodDeleteResponse> PhoneauthenticationmethodDeleteAsync()
        {
            var p = new PhoneauthenticationmethodDeleteParameter();
            return await this.SendAsync<PhoneauthenticationmethodDeleteParameter, PhoneauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PhoneauthenticationmethodDeleteResponse> PhoneauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PhoneauthenticationmethodDeleteParameter();
            return await this.SendAsync<PhoneauthenticationmethodDeleteParameter, PhoneauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PhoneauthenticationmethodDeleteResponse> PhoneauthenticationmethodDeleteAsync(PhoneauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<PhoneauthenticationmethodDeleteParameter, PhoneauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PhoneauthenticationmethodDeleteResponse> PhoneauthenticationmethodDeleteAsync(PhoneauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PhoneauthenticationmethodDeleteParameter, PhoneauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
