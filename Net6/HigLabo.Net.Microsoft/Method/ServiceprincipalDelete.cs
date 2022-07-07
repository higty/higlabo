using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id: return $"/servicePrincipals/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class ServiceprincipalDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteResponse> ServiceprincipalDeleteAsync()
        {
            var p = new ServiceprincipalDeleteParameter();
            return await this.SendAsync<ServiceprincipalDeleteParameter, ServiceprincipalDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteResponse> ServiceprincipalDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteParameter();
            return await this.SendAsync<ServiceprincipalDeleteParameter, ServiceprincipalDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteResponse> ServiceprincipalDeleteAsync(ServiceprincipalDeleteParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteParameter, ServiceprincipalDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteResponse> ServiceprincipalDeleteAsync(ServiceprincipalDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteParameter, ServiceprincipalDeleteResponse>(parameter, cancellationToken);
        }
    }
}
