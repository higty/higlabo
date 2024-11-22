using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalRemovepasswordParameter : IRestApiParameter
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
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        ServicePrincipals_Id_RemovePassword,
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
}
public partial class ServicePrincipalRemovepasswordResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalRemovepasswordResponse> ServicePrincipalRemovepasswordAsync()
    {
        var p = new ServicePrincipalRemovepasswordParameter();
        return await this.SendAsync<ServicePrincipalRemovepasswordParameter, ServicePrincipalRemovepasswordResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalRemovepasswordResponse> ServicePrincipalRemovepasswordAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalRemovepasswordParameter();
        return await this.SendAsync<ServicePrincipalRemovepasswordParameter, ServicePrincipalRemovepasswordResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalRemovepasswordResponse> ServicePrincipalRemovepasswordAsync(ServicePrincipalRemovepasswordParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalRemovepasswordParameter, ServicePrincipalRemovepasswordResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalRemovepasswordResponse> ServicePrincipalRemovepasswordAsync(ServicePrincipalRemovepasswordParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalRemovepasswordParameter, ServicePrincipalRemovepasswordResponse>(parameter, cancellationToken);
    }
}
