﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalAddpasswordParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_AddPassword: return $"/servicePrincipals/{Id}/addPassword";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_AddPassword,
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
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? CustomKeyIdentifier { get; set; }
        public string? Hint { get; set; }
        public Guid? KeyId { get; set; }
        public string? SecretText { get; set; }
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync()
        {
            var p = new ServiceprincipalAddpasswordParameter();
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalAddpasswordParameter();
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync(ServiceprincipalAddpasswordParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalAddpasswordResponse> ServiceprincipalAddpasswordAsync(ServiceprincipalAddpasswordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalAddpasswordParameter, ServiceprincipalAddpasswordResponse>(parameter, cancellationToken);
        }
    }
}
