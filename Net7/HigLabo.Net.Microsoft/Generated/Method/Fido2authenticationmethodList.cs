using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public partial class Fido2authenticationmethodListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_Fido2Methods: return $"/me/authentication/fido2Methods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_Fido2Methods: return $"/users/{IdOrUserPrincipalName}/authentication/fido2Methods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AaGuid,
            AttestationCertificates,
            AttestationLevel,
            CreatedDateTime,
            DisplayName,
            Id,
            Model,
        }
        public enum ApiPath
        {
            Me_Authentication_Fido2Methods,
            Users_IdOrUserPrincipalName_Authentication_Fido2Methods,
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
    public partial class Fido2authenticationmethodListResponse : RestApiResponse
    {
        public Fido2AuthenticationMethod[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync()
        {
            var p = new Fido2authenticationmethodListParameter();
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodListParameter();
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync(Fido2authenticationmethodListParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodListResponse> Fido2authenticationmethodListAsync(Fido2authenticationmethodListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(parameter, cancellationToken);
        }
    }
}
