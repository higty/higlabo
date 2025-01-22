using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalRemovekeyParameter : IRestApiParameter
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
public partial class ServicePrincipalRemovekeyResponse : RestApiResponse
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
    public async ValueTask<ServicePrincipalRemovekeyResponse> ServicePrincipalRemovekeyAsync()
    {
        var p = new ServicePrincipalRemovekeyParameter();
        return await this.SendAsync<ServicePrincipalRemovekeyParameter, ServicePrincipalRemovekeyResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalRemovekeyResponse> ServicePrincipalRemovekeyAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalRemovekeyParameter();
        return await this.SendAsync<ServicePrincipalRemovekeyParameter, ServicePrincipalRemovekeyResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalRemovekeyResponse> ServicePrincipalRemovekeyAsync(ServicePrincipalRemovekeyParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalRemovekeyParameter, ServicePrincipalRemovekeyResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-removekey?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalRemovekeyResponse> ServicePrincipalRemovekeyAsync(ServicePrincipalRemovekeyParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalRemovekeyParameter, ServicePrincipalRemovekeyResponse>(parameter, cancellationToken);
    }
}
