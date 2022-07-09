using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteOwnersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServicePrincipalsId { get; set; }
            public string? OwnersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_Owners_Id_ref: return $"/servicePrincipals/{ServicePrincipalsId}/owners/{OwnersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_Owners_Id_ref,
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
    public partial class ServiceprincipalDeleteOwnersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteOwnersResponse> ServiceprincipalDeleteOwnersAsync()
        {
            var p = new ServiceprincipalDeleteOwnersParameter();
            return await this.SendAsync<ServiceprincipalDeleteOwnersParameter, ServiceprincipalDeleteOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteOwnersResponse> ServiceprincipalDeleteOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteOwnersParameter();
            return await this.SendAsync<ServiceprincipalDeleteOwnersParameter, ServiceprincipalDeleteOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteOwnersResponse> ServiceprincipalDeleteOwnersAsync(ServiceprincipalDeleteOwnersParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteOwnersParameter, ServiceprincipalDeleteOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteOwnersResponse> ServiceprincipalDeleteOwnersAsync(ServiceprincipalDeleteOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteOwnersParameter, ServiceprincipalDeleteOwnersResponse>(parameter, cancellationToken);
        }
    }
}
