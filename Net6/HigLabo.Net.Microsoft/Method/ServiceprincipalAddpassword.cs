using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalAddpasswordParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_AddPassword,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_AddPassword: return $"/servicePrincipals/{Id}/addPassword";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string Id { get; set; }
    }
    public partial class ServiceprincipalAddpasswordResponse : RestApiResponse
    {
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Hint { get; set; }
        public Guid? KeyId { get; set; }
        public string? SecretText { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync()
        {
            var p = new ServiceprincipalAddpasswordParameter();
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalAddpasswordParameter();
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync(ServiceprincipalAddpasswordParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync(ServiceprincipalAddpasswordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(parameter, cancellationToken);
        }
    }
}
