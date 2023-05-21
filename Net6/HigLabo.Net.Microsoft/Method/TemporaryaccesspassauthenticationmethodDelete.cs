using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class TemporaryAccesspassauthenticationmethodDeleteParameter : IRestApiParameter
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
                    case ApiPath.Me_Authentication_TemporaryAccessPassMethods_Id: return $"/me/authentication/temporaryAccessPassMethods/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Authentication_TemporaryAccessPassMethods_Id,
            Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_Id,
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
    public partial class TemporaryAccesspassauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryAccesspassauthenticationmethodDeleteResponse> TemporaryAccesspassauthenticationmethodDeleteAsync()
        {
            var p = new TemporaryAccesspassauthenticationmethodDeleteParameter();
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodDeleteParameter, TemporaryAccesspassauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryAccesspassauthenticationmethodDeleteResponse> TemporaryAccesspassauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TemporaryAccesspassauthenticationmethodDeleteParameter();
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodDeleteParameter, TemporaryAccesspassauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryAccesspassauthenticationmethodDeleteResponse> TemporaryAccesspassauthenticationmethodDeleteAsync(TemporaryAccesspassauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodDeleteParameter, TemporaryAccesspassauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryAccesspassauthenticationmethodDeleteResponse> TemporaryAccesspassauthenticationmethodDeleteAsync(TemporaryAccesspassauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodDeleteParameter, TemporaryAccesspassauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
