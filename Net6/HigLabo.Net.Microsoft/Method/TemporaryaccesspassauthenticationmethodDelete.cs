using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TemporaryaccesspassauthenticationmethodDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_Id,
            Me_Authentication_TemporaryAccessPassMethods_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods/{Id}";
                    case ApiPath.Me_Authentication_TemporaryAccessPassMethods_Id: return $"/me/authentication/temporaryAccessPassMethods/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class TemporaryaccesspassauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodDeleteResponse> TemporaryaccesspassauthenticationmethodDeleteAsync()
        {
            var p = new TemporaryaccesspassauthenticationmethodDeleteParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodDeleteParameter, TemporaryaccesspassauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodDeleteResponse> TemporaryaccesspassauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TemporaryaccesspassauthenticationmethodDeleteParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodDeleteParameter, TemporaryaccesspassauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodDeleteResponse> TemporaryaccesspassauthenticationmethodDeleteAsync(TemporaryaccesspassauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodDeleteParameter, TemporaryaccesspassauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodDeleteResponse> TemporaryaccesspassauthenticationmethodDeleteAsync(TemporaryaccesspassauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodDeleteParameter, TemporaryaccesspassauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
