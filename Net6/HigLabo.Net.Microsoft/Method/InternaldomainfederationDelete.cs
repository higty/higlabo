using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InternaldomainfederationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Domains_DomainsId_FederationConfiguration_InternalDomainFederationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_DomainsId_FederationConfiguration_InternalDomainFederationId: return $"/domains/{DomainsId}/federationConfiguration/{InternalDomainFederationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DomainsId { get; set; }
        public string InternalDomainFederationId { get; set; }
    }
    public partial class InternaldomainfederationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationDeleteResponse> InternaldomainfederationDeleteAsync()
        {
            var p = new InternaldomainfederationDeleteParameter();
            return await this.SendAsync<InternaldomainfederationDeleteParameter, InternaldomainfederationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationDeleteResponse> InternaldomainfederationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new InternaldomainfederationDeleteParameter();
            return await this.SendAsync<InternaldomainfederationDeleteParameter, InternaldomainfederationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationDeleteResponse> InternaldomainfederationDeleteAsync(InternaldomainfederationDeleteParameter parameter)
        {
            return await this.SendAsync<InternaldomainfederationDeleteParameter, InternaldomainfederationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationDeleteResponse> InternaldomainfederationDeleteAsync(InternaldomainfederationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InternaldomainfederationDeleteParameter, InternaldomainfederationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
