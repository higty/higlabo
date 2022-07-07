using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Fido2authenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_Fido2Methods_Id,
            Users_IdOrUserPrincipalName_Authentication_Fido2Methods_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_Fido2Methods_Id: return $"/me/authentication/fido2Methods/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_Fido2Methods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/fido2Methods/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class Fido2authenticationmethodGetResponse : RestApiResponse
    {
        public enum Fido2AuthenticationMethodAttestationLevel
        {
            Attested,
            NotAttested,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? AaGuid { get; set; }
        public string? Model { get; set; }
        public String[]? AttestationCertificates { get; set; }
        public Fido2AuthenticationMethodAttestationLevel AttestationLevel { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodGetResponse> Fido2authenticationmethodGetAsync()
        {
            var p = new Fido2authenticationmethodGetParameter();
            return await this.SendAsync<Fido2authenticationmethodGetParameter, Fido2authenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodGetResponse> Fido2authenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodGetParameter();
            return await this.SendAsync<Fido2authenticationmethodGetParameter, Fido2authenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodGetResponse> Fido2authenticationmethodGetAsync(Fido2authenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodGetParameter, Fido2authenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodGetResponse> Fido2authenticationmethodGetAsync(Fido2authenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodGetParameter, Fido2authenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
