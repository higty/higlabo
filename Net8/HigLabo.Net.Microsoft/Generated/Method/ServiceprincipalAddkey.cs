using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalAddkeyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Serviceprincipals_Id_AddKey: return $"/serviceprincipals/{Id}/addKey";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Serviceprincipals_Id_AddKey,
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
        public KeyCredential? KeyCredential { get; set; }
        public PasswordCredential? PasswordCredential { get; set; }
        public string? Proof { get; set; }
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Key { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
    }
    public partial class ServicePrincipalAddkeyResponse : RestApiResponse
    {
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Key { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddkeyResponse> ServicePrincipalAddkeyAsync()
        {
            var p = new ServicePrincipalAddkeyParameter();
            return await this.SendAsync<ServicePrincipalAddkeyParameter, ServicePrincipalAddkeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddkeyResponse> ServicePrincipalAddkeyAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalAddkeyParameter();
            return await this.SendAsync<ServicePrincipalAddkeyParameter, ServicePrincipalAddkeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddkeyResponse> ServicePrincipalAddkeyAsync(ServicePrincipalAddkeyParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalAddkeyParameter, ServicePrincipalAddkeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddkeyResponse> ServicePrincipalAddkeyAsync(ServicePrincipalAddkeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalAddkeyParameter, ServicePrincipalAddkeyResponse>(parameter, cancellationToken);
        }
    }
}
