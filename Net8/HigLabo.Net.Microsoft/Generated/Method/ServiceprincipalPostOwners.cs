using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalPostOwnersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_Owners_ref: return $"/servicePrincipals/{Id}/owners/$ref";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_Owners_ref,
            ServicePrincipals,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class ServiceprincipalPostOwnersResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync()
        {
            var p = new ServiceprincipalPostOwnersParameter();
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostOwnersParameter();
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync(ServiceprincipalPostOwnersParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalPostOwnersResponse> ServiceprincipalPostOwnersAsync(ServiceprincipalPostOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostOwnersParameter, ServiceprincipalPostOwnersResponse>(parameter, cancellationToken);
        }
    }
}
