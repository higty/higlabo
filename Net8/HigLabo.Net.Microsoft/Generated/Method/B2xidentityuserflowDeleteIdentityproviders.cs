using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
/// </summary>
public partial class B2xidentityUserflowDeleteIdentityProvidersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? B2xUserFlowsId { get; set; }
        public string? IdentityProvidersId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_B2xUserFlows_Id_IdentityProviders_Id_ref: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/identityProviders/{IdentityProvidersId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Identity_B2xUserFlows_Id_IdentityProviders_Id_ref,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class B2xidentityUserflowDeleteIdentityProvidersResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteIdentityProvidersResponse> B2xidentityUserflowDeleteIdentityProvidersAsync()
    {
        var p = new B2xidentityUserflowDeleteIdentityProvidersParameter();
        return await this.SendAsync<B2xidentityUserflowDeleteIdentityProvidersParameter, B2xidentityUserflowDeleteIdentityProvidersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteIdentityProvidersResponse> B2xidentityUserflowDeleteIdentityProvidersAsync(CancellationToken cancellationToken)
    {
        var p = new B2xidentityUserflowDeleteIdentityProvidersParameter();
        return await this.SendAsync<B2xidentityUserflowDeleteIdentityProvidersParameter, B2xidentityUserflowDeleteIdentityProvidersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteIdentityProvidersResponse> B2xidentityUserflowDeleteIdentityProvidersAsync(B2xidentityUserflowDeleteIdentityProvidersParameter parameter)
    {
        return await this.SendAsync<B2xidentityUserflowDeleteIdentityProvidersParameter, B2xidentityUserflowDeleteIdentityProvidersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteIdentityProvidersResponse> B2xidentityUserflowDeleteIdentityProvidersAsync(B2xidentityUserflowDeleteIdentityProvidersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<B2xidentityUserflowDeleteIdentityProvidersParameter, B2xidentityUserflowDeleteIdentityProvidersResponse>(parameter, cancellationToken);
    }
}
