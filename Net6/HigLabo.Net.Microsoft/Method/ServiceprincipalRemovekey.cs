using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalRemovekeyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Serviceprincipals_Id_RemoveKey: return $"/serviceprincipals/{Id}/removeKey";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Serviceprincipals_Id_RemoveKey,
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
        public Guid? KeyId { get; set; }
        public string? Proof { get; set; }
    }
    public partial class ServiceprincipalRemovekeyResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync()
        {
            var p = new ServiceprincipalRemovekeyParameter();
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalRemovekeyParameter();
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync(ServiceprincipalRemovekeyParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalRemovekeyResponse> ServiceprincipalRemovekeyAsync(ServiceprincipalRemovekeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalRemovekeyParameter, ServiceprincipalRemovekeyResponse>(parameter, cancellationToken);
        }
    }
}
