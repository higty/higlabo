using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalRemovepasswordParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_RemovePassword: return $"/servicePrincipals/{Id}/removePassword";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_RemovePassword,
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
        public Guid? KeyId { get; set; }
    }
    public partial class ServiceprincipalRemovepasswordResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovepasswordResponse> ServiceprincipalRemovepasswordAsync()
        {
            var p = new ServiceprincipalRemovepasswordParameter();
            return await this.SendAsync<ServiceprincipalRemovepasswordParameter, ServiceprincipalRemovepasswordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovepasswordResponse> ServiceprincipalRemovepasswordAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalRemovepasswordParameter();
            return await this.SendAsync<ServiceprincipalRemovepasswordParameter, ServiceprincipalRemovepasswordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovepasswordResponse> ServiceprincipalRemovepasswordAsync(ServiceprincipalRemovepasswordParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalRemovepasswordParameter, ServiceprincipalRemovepasswordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovepasswordResponse> ServiceprincipalRemovepasswordAsync(ServiceprincipalRemovepasswordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalRemovepasswordParameter, ServiceprincipalRemovepasswordResponse>(parameter, cancellationToken);
        }
    }
}
