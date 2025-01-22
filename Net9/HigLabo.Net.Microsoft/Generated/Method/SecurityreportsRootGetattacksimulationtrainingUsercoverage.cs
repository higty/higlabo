using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
/// </summary>
public partial class SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_Security_GetAttackSimulationTrainingUserCoverage: return $"/reports/security/getAttackSimulationTrainingUserCoverage";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_Security_GetAttackSimulationTrainingUserCoverage,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse : RestApiResponse<AttackSimulationTrainingUserCoverage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse> SecurityreportsRootGetattackSimulationtrainingUsercoverageAsync()
    {
        var p = new SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter();
        return await this.SendAsync<SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter, SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse> SecurityreportsRootGetattackSimulationtrainingUsercoverageAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter();
        return await this.SendAsync<SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter, SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse> SecurityreportsRootGetattackSimulationtrainingUsercoverageAsync(SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter parameter)
    {
        return await this.SendAsync<SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter, SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse> SecurityreportsRootGetattackSimulationtrainingUsercoverageAsync(SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter, SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AttackSimulationTrainingUserCoverage> SecurityreportsRootGetattackSimulationtrainingUsercoverageEnumerateAsync(SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SecurityreportsRootGetattackSimulationtrainingUsercoverageParameter, SecurityreportsRootGetattackSimulationtrainingUsercoverageResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AttackSimulationTrainingUserCoverage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
