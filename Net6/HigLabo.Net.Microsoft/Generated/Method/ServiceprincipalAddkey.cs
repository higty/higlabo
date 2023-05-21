using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalAddkeyParameter : IRestApiParameter
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
    public partial class ServiceprincipalAddkeyResponse : RestApiResponse
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
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync()
        {
            var p = new ServiceprincipalAddkeyParameter();
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalAddkeyParameter();
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync(ServiceprincipalAddkeyParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync(ServiceprincipalAddkeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(parameter, cancellationToken);
        }
    }
}
