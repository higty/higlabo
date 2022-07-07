using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Fido2authenticationmethodListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_Fido2Methods,
            Users_IdOrUserPrincipalName_Authentication_Fido2Methods,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_Fido2Methods: return $"/me/authentication/fido2Methods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_Fido2Methods: return $"/users/{IdOrUserPrincipalName}/authentication/fido2Methods";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class Fido2authenticationmethodListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/fido2authenticationmethod?view=graph-rest-1.0
        /// </summary>
        public partial class Fido2AuthenticationMethod
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

        public Fido2AuthenticationMethod[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync()
        {
            var p = new Fido2authenticationmethodListParameter();
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodListParameter();
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync(Fido2authenticationmethodListParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync(Fido2authenticationmethodListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(parameter, cancellationToken);
        }
    }
}
