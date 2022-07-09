using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InternaldomainfederationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DomainsId { get; set; }
            public string? InternalDomainFederationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_DomainsId_FederationConfiguration_InternalDomainFederationId: return $"/domains/{DomainsId}/federationConfiguration/{InternalDomainFederationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Domains_DomainsId_FederationConfiguration_InternalDomainFederationId,
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
