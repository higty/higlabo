using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalRemovekeyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_RemoveKey: return $"/servicePrincipals/{Id}/removeKey";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_RemoveKey,
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
        public string? Proof { get; set; }
    }
    public partial class ServiceprincipalRemovekeyResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync()
        {
            var p = new ServiceprincipalRemovekeyParameter();
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalRemovekeyParameter();
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync(ServiceprincipalRemovekeyParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync(ServiceprincipalRemovekeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(parameter, cancellationToken);
        }
    }
}
