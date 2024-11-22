using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-security-runhuntingquery?view=graph-rest-1.0
/// </summary>
public partial class SecuritySecurityRunhuntingqueryParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_RunHuntingQuery: return $"/security/runHuntingQuery";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Security_RunHuntingQuery,
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
    public string? Query { get; set; }
    public SinglePropertySchema[]? Schema { get; set; }
    public HuntingRowResult[]? Results { get; set; }
}
public partial class SecuritySecurityRunhuntingqueryResponse : RestApiResponse
{
    public SinglePropertySchema[]? Schema { get; set; }
    public HuntingRowResult[]? Results { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-security-runhuntingquery?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-security-runhuntingquery?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecuritySecurityRunhuntingqueryResponse> SecuritySecurityRunhuntingqueryAsync()
    {
        var p = new SecuritySecurityRunhuntingqueryParameter();
        return await this.SendAsync<SecuritySecurityRunhuntingqueryParameter, SecuritySecurityRunhuntingqueryResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-security-runhuntingquery?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecuritySecurityRunhuntingqueryResponse> SecuritySecurityRunhuntingqueryAsync(CancellationToken cancellationToken)
    {
        var p = new SecuritySecurityRunhuntingqueryParameter();
        return await this.SendAsync<SecuritySecurityRunhuntingqueryParameter, SecuritySecurityRunhuntingqueryResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-security-runhuntingquery?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecuritySecurityRunhuntingqueryResponse> SecuritySecurityRunhuntingqueryAsync(SecuritySecurityRunhuntingqueryParameter parameter)
    {
        return await this.SendAsync<SecuritySecurityRunhuntingqueryParameter, SecuritySecurityRunhuntingqueryResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-security-runhuntingquery?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecuritySecurityRunhuntingqueryResponse> SecuritySecurityRunhuntingqueryAsync(SecuritySecurityRunhuntingqueryParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecuritySecurityRunhuntingqueryParameter, SecuritySecurityRunhuntingqueryResponse>(parameter, cancellationToken);
    }
}
