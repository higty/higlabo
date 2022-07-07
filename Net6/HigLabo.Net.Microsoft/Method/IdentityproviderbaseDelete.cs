using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderbaseDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_IdentityProviders_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_IdentityProviders_Id: return $"/identity/identityProviders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class IdentityproviderbaseDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync()
        {
            var p = new IdentityproviderbaseDeleteParameter();
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderbaseDeleteParameter();
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync(IdentityproviderbaseDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync(IdentityproviderbaseDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(parameter, cancellationToken);
        }
    }
}
