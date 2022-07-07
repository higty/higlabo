using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SecurityListSecurescoresParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_SecureScores,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Security_SecureScores: return $"/security/secureScores";
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
    }
    public partial class SecurityListSecurescoresResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/security-list-securescores?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityListSecurescoresResponse> SecurityListSecurescoresAsync()
        {
            var p = new SecurityListSecurescoresParameter();
            return await this.SendAsync<SecurityListSecurescoresParameter, SecurityListSecurescoresResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/security-list-securescores?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityListSecurescoresResponse> SecurityListSecurescoresAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityListSecurescoresParameter();
            return await this.SendAsync<SecurityListSecurescoresParameter, SecurityListSecurescoresResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/security-list-securescores?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityListSecurescoresResponse> SecurityListSecurescoresAsync(SecurityListSecurescoresParameter parameter)
        {
            return await this.SendAsync<SecurityListSecurescoresParameter, SecurityListSecurescoresResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/security-list-securescores?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityListSecurescoresResponse> SecurityListSecurescoresAsync(SecurityListSecurescoresParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityListSecurescoresParameter, SecurityListSecurescoresResponse>(parameter, cancellationToken);
        }
    }
}
