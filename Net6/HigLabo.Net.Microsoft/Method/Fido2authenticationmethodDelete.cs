using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Fido2authenticationmethodDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_Authentication_Fido2Methods_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_Fido2Methods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/fido2Methods/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class Fido2authenticationmethodDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync()
        {
            var p = new Fido2authenticationmethodDeleteParameter();
            return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodDeleteParameter();
            return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync(Fido2authenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync(Fido2authenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
