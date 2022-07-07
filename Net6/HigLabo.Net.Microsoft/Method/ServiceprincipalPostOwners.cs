using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostOwnersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_Owners_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_Owners_ref: return $"/servicePrincipals/{Id}/owners/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ServiceprincipalPostOwnersResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync()
        {
            var p = new ServiceprincipalPostOwnersParameter();
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostOwnersParameter();
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync(ServiceprincipalPostOwnersParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync(ServiceprincipalPostOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(parameter, cancellationToken);
        }
    }
}
