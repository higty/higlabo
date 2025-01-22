using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-casesroot-delete-ediscoverycases?view=graph-rest-1.0
/// </summary>
public partial class SecurityCasesRootDeleteEDiscoverycasesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId,
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
public partial class SecurityCasesRootDeleteEDiscoverycasesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-casesroot-delete-ediscoverycases?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-delete-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCasesRootDeleteEDiscoverycasesResponse> SecurityCasesRootDeleteEDiscoverycasesAsync()
    {
        var p = new SecurityCasesRootDeleteEDiscoverycasesParameter();
        return await this.SendAsync<SecurityCasesRootDeleteEDiscoverycasesParameter, SecurityCasesRootDeleteEDiscoverycasesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-delete-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCasesRootDeleteEDiscoverycasesResponse> SecurityCasesRootDeleteEDiscoverycasesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityCasesRootDeleteEDiscoverycasesParameter();
        return await this.SendAsync<SecurityCasesRootDeleteEDiscoverycasesParameter, SecurityCasesRootDeleteEDiscoverycasesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-delete-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCasesRootDeleteEDiscoverycasesResponse> SecurityCasesRootDeleteEDiscoverycasesAsync(SecurityCasesRootDeleteEDiscoverycasesParameter parameter)
    {
        return await this.SendAsync<SecurityCasesRootDeleteEDiscoverycasesParameter, SecurityCasesRootDeleteEDiscoverycasesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-delete-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityCasesRootDeleteEDiscoverycasesResponse> SecurityCasesRootDeleteEDiscoverycasesAsync(SecurityCasesRootDeleteEDiscoverycasesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityCasesRootDeleteEDiscoverycasesParameter, SecurityCasesRootDeleteEDiscoverycasesResponse>(parameter, cancellationToken);
    }
}
