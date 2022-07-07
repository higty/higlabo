using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SamlorwsfedexternaldomainfederationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Irectory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Irectory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID: return $"/irectory/federationConfigurations/{SamlOrWsFedExternalDomainFederationID}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SamlOrWsFedExternalDomainFederationID { get; set; }
    }
    public partial class SamlorwsfedexternaldomainfederationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationDeleteParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationDeleteParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync(SamlorwsfedexternaldomainfederationDeleteParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync(SamlorwsfedexternaldomainfederationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
