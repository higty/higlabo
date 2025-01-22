using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalAddpasswordParameter : IRestApiParameter
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
public partial class ServicePrincipalAddpasswordResponse : RestApiResponse
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
    public async ValueTask<ServicePrincipalAddpasswordResponse> ServicePrincipalAddpasswordAsync()
    {
        var p = new ServicePrincipalAddpasswordParameter();
        return await this.SendAsync<ServicePrincipalAddpasswordParameter, ServicePrincipalAddpasswordResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalAddpasswordResponse> ServicePrincipalAddpasswordAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalAddpasswordParameter();
        return await this.SendAsync<ServicePrincipalAddpasswordParameter, ServicePrincipalAddpasswordResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalAddpasswordResponse> ServicePrincipalAddpasswordAsync(ServicePrincipalAddpasswordParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalAddpasswordParameter, ServicePrincipalAddpasswordResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addpassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalAddpasswordResponse> ServicePrincipalAddpasswordAsync(ServicePrincipalAddpasswordParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalAddpasswordParameter, ServicePrincipalAddpasswordResponse>(parameter, cancellationToken);
    }
}
