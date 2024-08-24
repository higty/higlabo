using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

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
    public partial class Fido2authenticationmethodListResponse : RestApiResponse<Fido2AuthenticationMethod>
    {
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
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Fido2AuthenticationMethod> Fido2authenticationmethodListEnumerateAsync(Fido2authenticationmethodListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<Fido2authenticationmethodListParameter, Fido2authenticationmethodListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Fido2AuthenticationMethod>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
