using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
    /// </summary>
    public partial class SamlorwsfedexternaldomainfederationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SamlOrWsFedExternalDomainFederationID { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Irectory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID: return $"/irectory/federationConfigurations/{SamlOrWsFedExternalDomainFederationID}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Irectory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID,
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
    public partial class SamlorwsfedexternaldomainfederationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationDeleteParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationDeleteParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync(SamlorwsfedexternaldomainfederationDeleteParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationDeleteResponse> SamlorwsfedexternaldomainfederationDeleteAsync(SamlorwsfedexternaldomainfederationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationDeleteParameter, SamlorwsfedexternaldomainfederationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
