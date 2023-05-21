using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethod-resetpassword?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationmethodResetpasswordParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_Methods_Id_ResetPassword: return $"/users/{IdOrUserPrincipalName}/authentication/methods/{Id}/resetPassword";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_Authentication_Methods_Id_ResetPassword,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? NewPassword { get; set; }
    }
    public partial class AuthenticationmethodResetpasswordResponse : RestApiResponse
    {
        public string? NewPassword { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethod-resetpassword?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethod-resetpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodResetpasswordResponse> AuthenticationmethodResetpasswordAsync()
        {
            var p = new AuthenticationmethodResetpasswordParameter();
            return await this.SendAsync<AuthenticationmethodResetpasswordParameter, AuthenticationmethodResetpasswordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethod-resetpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodResetpasswordResponse> AuthenticationmethodResetpasswordAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationmethodResetpasswordParameter();
            return await this.SendAsync<AuthenticationmethodResetpasswordParameter, AuthenticationmethodResetpasswordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethod-resetpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodResetpasswordResponse> AuthenticationmethodResetpasswordAsync(AuthenticationmethodResetpasswordParameter parameter)
        {
            return await this.SendAsync<AuthenticationmethodResetpasswordParameter, AuthenticationmethodResetpasswordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethod-resetpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodResetpasswordResponse> AuthenticationmethodResetpasswordAsync(AuthenticationmethodResetpasswordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationmethodResetpasswordParameter, AuthenticationmethodResetpasswordResponse>(parameter, cancellationToken);
        }
    }
}
